using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var reader = new StreamReader(@"C:\Users\HP\source\repos\Sales.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
