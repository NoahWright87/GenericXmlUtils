using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace GenericXmlUtils
{
    public class Class1
    {



        public void CalculateFillRates(List<string> filePaths)
        {
            Dictionary<string, int> totals = new Dictionary<string, int>();

            foreach (var filePath in filePaths)
            {
                var reader = XmlReader.Create(filePath);
                var doc = XDocument.Load(filePath);

                foreach (var d in doc.Descendants())
                {
                    Console.WriteLine(d.BaseUri);
                    if (!totals.ContainsKey(d.BaseUri)) totals.Add(d.BaseUri, 0);
                    totals[d.BaseUri]++;
                }
            }

            //Spit out the contents of Dictionary in some human-readable format
        }
    }
}
