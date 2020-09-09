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
            using (Process compiler = new Process())
            {
                compiler.StartInfo.FileName = @"C:\Users\HP\source\repos\CaseStudyRough\Sender\bin\Debug\Sender.exe";
                compiler.StartInfo.Arguments = "/r:System.dll /out:sample.exe stdstr.cs";
                compiler.StartInfo.UseShellExecute = false;
                compiler.StartInfo.RedirectStandardOutput = true;
                compiler.Start();

                Console.WriteLine(compiler.StandardOutput.ReadToEnd());

                compiler.WaitForExit();
            }



            
            
        }
    }
}
