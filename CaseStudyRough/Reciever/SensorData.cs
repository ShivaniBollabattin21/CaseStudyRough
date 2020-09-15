using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciever
{
    public class SensorData
    {
        public string SensorId;
        public DateTime FootFallTimeStamp;

        public SensorData(string senorId, string timestamp)
        {
            SensorId = senorId;
            FootFallTimeStamp = DateTime.Parse(timestamp);
        }
    }
}
