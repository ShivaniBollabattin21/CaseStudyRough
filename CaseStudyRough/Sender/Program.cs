using InputOutputHandler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Sender
{
    class Sender
    {
       IInputHandler _IInputHandler;
       IOutputHandler _IOutputHandler;
        public Sender(IInputHandler TargetInputParameter, IOutputHandler TargetOutputParameter)
        {
            _IInputHandler = TargetInputParameter;
            _IOutputHandler = TargetOutputParameter;
        }

        public List<string> _SenderReadingInputData()
        {
            return _IInputHandler.ReadInput();
        }

        public void _SenderWritingOuptutData(List<string> OutputDataParameter)
        {
            _IOutputHandler.WriteOutput(OutputDataParameter);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Sales.csv";

            IInputHandler _InputDeviceOfSender = new CSVFileInputOutputProcessor(filePath);
            IOutputHandler _OutputDeviceOfSender = new ConsoleInputOutputProcessor();
            
            Sender _senderInputOutputDevice = new Sender( _InputDeviceOfSender, _OutputDeviceOfSender );
            
            List<string> data = _senderInputOutputDevice._SenderReadingInputData();

            _senderInputOutputDevice._SenderWritingOuptutData(data);

            Console.ReadKey();

        }
    }
}
