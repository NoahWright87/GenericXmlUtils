using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace GenericXmlUtils
{
    public class XmlUtils
    {
        public static Dictionary<string, int> CalculateFillRates(List<string> filePaths)
        {
            Dictionary<string, int> totals = new Dictionary<string, int>();

            foreach (var filePath in filePaths)
            {
                var reader = XmlReader.Create(filePath);
                var doc = XDocument.Load(filePath);

                foreach (var d in doc.Descendants())
                {
                    var nodePath = d.GetPath();
                    Console.WriteLine(nodePath);
                    
                    if (!totals.ContainsKey(nodePath)) totals.Add(nodePath, 0);
                    //Add to total if there is a value or attribute in the node
                    if (!string.IsNullOrWhiteSpace(d.Value)
                        || d.Attributes().Any(x => !string.IsNullOrWhiteSpace(x.Value)))
                    {
                        totals[nodePath]++;
                    }
                }
            }

            //TODO: As is, if a node appears multiple times (eg: Subject) it gets counted repeatedly - how to best avoid this??
            return totals;
        }
        public static void ExportFillRatesToFile(string outputPath, List<string> filePaths)
        {
            var result = CalculateFillRates(filePaths);

            //TODO: Export the results to the outputPath
        }

        public static void CompareXmls(string xml1, string xml2)
        {
            //TODO: Compare 2 XMLs, generate a report about what's different, including
            //  Nodes themselves (do names match 100%)
            //  Node values
            //Perhaps include settings so that empty tag and null are seen as identical, or empty string and null are identical
        }
        //TODO: Export results of CompareXmls to a file
    }

    public static class XmlExtensions
    {
        public static string GetPath(this XElement node)
        {
            string path = node.Name.ToString();
            XElement currentNode = node;
            while (currentNode.Parent != null)
            {
                currentNode = currentNode.Parent;
                path = currentNode.Name.ToString() + @"\" + path;
            }
            return path;
        }

    }
}