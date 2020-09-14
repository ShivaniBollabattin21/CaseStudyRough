using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputOutputHandler
{
     public interface IInputHandler
    {
      List<string> ReadInput();
      

    }
    public interface IOutputHandler
    {
        //List<string> ReadInput();
        void WriteOutput(List<string> data);

    }
    public class CSVFileInputOutputProcessor : IInputHandler, IOutputHandler
    {
       public string _CsvFilePath { get; set; }
        public CSVFileInputOutputProcessor(string filepath)
        {
            this._CsvFilePath = filepath;
        }
       public List<string> ReadInput()
       {

            List<string> _DataReadFromCSVFile = new List<string>();
            try
            {
               
                using (var reader = new StreamReader(_CsvFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        _DataReadFromCSVFile.Add(line);           
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return _DataReadFromCSVFile;
       }

        public void WriteOutput(List<string> data)
        {

        }
    }

    public class ConsoleInputOutputProcessor : IInputHandler, IOutputHandler
    {
        
        public ConsoleInputOutputProcessor(){ }
        public List<string> ReadInput()
        {

            List<string> _DataReadFromConsole = new List<string>();
            try
            {

                string data = string.Empty;
                while ((data = Console.ReadLine()) != null)
                {
                    _DataReadFromConsole.Add(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return _DataReadFromConsole;
        }

        public void WriteOutput(List<string> data)
        {
            foreach(string d in data)
            {
                Console.WriteLine(d);
            }   

        }
    }
}
