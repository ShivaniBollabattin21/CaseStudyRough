using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciever
{
    public class SensorDataGroup
    {
        public string Key { get; set; }
        public List<SensorData> SensorDataGroupList { get; set; }
        public int GroupCount { get; set; }
        //public double GroupAverage { get; set; }


    }


}
