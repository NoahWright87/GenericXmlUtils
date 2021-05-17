using GenericXmlUtils;
using System;
using System.IO;
using System.Linq;

namespace TestConsole
{
    /// <summary>
    /// This class is just so I can see the results while testing
    /// </summary>
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var paths = Directory.GetFiles(@"C:\Users\up7819\OneDrive - Alfa Companies\Desktop\Task Notes\Lexis Nexis Services\").ToList();

            //List<string> paths = new List<string>()
            //{
            //    @"C:\Users\up7819\OneDrive - Alfa Companies\Desktop\Task Notes\Lexis Nexis Services\CLUE_Auto.txt"
            //};

            XmlUtils.CalculateFillRates(paths);

            Console.ReadLine();
        }
    }
}
