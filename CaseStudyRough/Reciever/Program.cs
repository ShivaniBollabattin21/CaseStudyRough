using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciever
{
    class Program
    {
        static void Main(string[] args)
        {
             string data = string.Empty;
                while ((data = Console.ReadLine()) != null)
                {
                    Console.WriteLine($"Got From sender ......{data}");
                }
        }
    }
}
