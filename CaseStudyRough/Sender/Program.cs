using InputOutputHandler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\HP\source\repos\Sales.csv";
            CSVFileProcessor _csvFileProcessor = new CSVFileProcessor(filePath);
            List<string> data = _csvFileProcessor.ReadCSVFileAndReturnData();
            for(int i =0;i<data.Count;i++)
            {
                Console.WriteLine(data[i]);
            }
            Console.ReadKey();

        }
    }
}
