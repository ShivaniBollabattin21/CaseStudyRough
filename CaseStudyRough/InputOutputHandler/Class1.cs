using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputOutputHandler
{
     interface IInputOutputHandler
    {
      void ReadInput();
      void WriteOutput();

    }
    public class CSVFileProcessor
    {
       public string FilePath { get; set; }
        public CSVFileProcessor(string filepath)
        {
            this.FilePath = filepath;
        }
       public List<string> ReadInput()
       {

            List<string> csvData = new List<string>();
            try
            {
               
                using (var reader = new StreamReader(this.FilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();  
                        csvData.Add(line);           
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return csvData;
       }

        public void WriteOutput()
        {

        }
        
    }
}
