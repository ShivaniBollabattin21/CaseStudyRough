using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Reciever
{
    public class Statistics
    {
        

        public static Dictionary<string,double> CalculateAverage(Dictionary<string, List<SensorData>> sensorDataDict)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();

            double allDictCount = CountAllDictionaryElements(sensorDataDict);

            foreach(var element in sensorDataDict)
            {
                dict.Add(element.Key, element.Value.Count / allDictCount);
            }

            return dict;
        }

        public static int CountAllDictionaryElements(Dictionary<string, List<SensorData>> sensorDataDict)
        {
            int sum = 0;
            foreach (var element in sensorDataDict)
            {
                sum += element.Value.Count;
            }
            return sum;
        }
        
    }
}
