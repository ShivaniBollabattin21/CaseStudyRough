using InputOutputHandler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Sender
{
    
    class SenderMain
    {
        static void Main(string[] args)
        {
            string filePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\FootfallSensorData.csv";

            IInputHandler _InputDeviceOfSender = new CSVFileInputOutputProcessor(filePath);
            IOutputHandler _OutputDeviceOfSender = new ConsoleInputOutputProcessor();
            
            Sender _senderInputOutputDevice = new Sender( _InputDeviceOfSender, _OutputDeviceOfSender );
            
            List<string> data = _senderInputOutputDevice.ReadInputData();

            _senderInputOutputDevice.WriteOuptutData(data);

        }
    }
}
