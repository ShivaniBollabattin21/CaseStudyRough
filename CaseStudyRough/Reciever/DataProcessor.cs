using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciever
{

    
    class DataProcessor
    {
        public static List<SensorData> ConvertDataToSensorDataList(List<string> csvData)
        {
            List<SensorData> SensorDataArray = new List<SensorData>();
            for (var i = 1; i < csvData.Count; i++)
            {
                var str = csvData[i].Split(',');
                SensorDataArray.Add(new SensorData(str[0], str[1]));
            }

            return SensorDataArray;
        }

        public Dictionary<string, List<SensorData>> GroupSensorDataBasedOnInterval(List<SensorData> sensorDataList, Func<DateTime, string> func)
        {
            Dictionary<string, List<SensorData>> hourlyData = new Dictionary<string, List<SensorData>>();
            foreach (SensorData sensorData in sensorDataList)
            {
                string hourKey = sensorData.SensorId + "," + func.Invoke(sensorData.FootFallTimeStamp);
                //string hourKey = GetHourKey(sensorData.FootFallTimeStamp);
                if (!hourlyData.ContainsKey(hourKey))
                {
                    hourlyData.Add(hourKey, new List<SensorData>());
                }
                hourlyData[hourKey].Add(sensorData);
            }
            return hourlyData;
        }

        public string GetHourKey(DateTime timeStamp)
        {
            return timeStamp.ToString("yyyy/MM/dd HH");
        }

        public string GetDayKey(DateTime timeStamp)
        {
            return timeStamp.ToString("yyyy/MM/dd");
        }

        public string GetWeekKey(DateTime timeStamp)
        {
            return GetWeekNumber1(timeStamp).ToString();
        }

        int GetWeekNumber1(DateTime timestamp)
        {

            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(timestamp);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                timestamp = timestamp.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(timestamp, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        }

    }
}


