using System;
using InputOutputHandler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Reciever
{

    class ReceiverMain
    {
        static DataProcessor dataProcessor = new DataProcessor();

        static void Main(string[] args)
        {

            string filePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Sales.csv";

            IInputHandler _InputDeviceOfSender = new ConsoleInputOutputProcessor();
            IOutputHandler _OutputDeviceOfSender = new CSVFileInputOutputProcessor(filePath);

            Receiver receiverInputOutputDevice = new Receiver(_InputDeviceOfSender, _OutputDeviceOfSender);

            List<string> data = receiverInputOutputDevice.ReadInputData();

            
            Func<DateTime, string> hourPointer = new Func<DateTime, string>(dataProcessor.GetHourKey);
            Func<DateTime, string> dayPointer = new Func<DateTime, string>(dataProcessor.GetDayKey);
            Func<DateTime, string> weekPointer = new Func<DateTime, string>(dataProcessor.GetWeekKey);


            List<SensorData> SensorDataList = DataProcessor.ConvertDataToSensorDataList(data);

            var hourDataList = calcaluteAverage(SensorDataList,hourPointer);
            var dayDataList  = calcaluteAverage(SensorDataList,dayPointer);

            receiverInputOutputDevice.WriteOuptutData(hourDataList);
            receiverInputOutputDevice.WriteOuptutData(dayDataList);
        }

        public static List<string> calcaluteAverage(List<SensorData> SensorDataList, Func<DateTime,string> functionPointer){
          
            
            var DictData = dataProcessor.GroupSensorDataBasedOnInterval(SensorDataList, functionPointer);
            var avg = Statistics.CalculateAverage(DictData);
            var strList = formatDataIntoString(avg);

            return strList;
        }

        public static List<string> formatDataIntoString(Dictionary<string,double> dataDictionary)
        {
            List<string> stringList = new List<string>();
            string str = string.Empty;
            foreach (var element in dataDictionary)
            {
                 str = element.Key.ToString() + "," + element.Value.ToString();

                 stringList.Add(str);
            }
            return stringList;
        }

    }
}
