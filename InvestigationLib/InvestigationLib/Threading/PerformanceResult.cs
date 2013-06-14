using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationLib.Threading
{
    public class PerformanceResult
    {
        public PerformanceResult(long elapsedTime, List<KeyValuePair<int, short>> listTest)
        {
            ElapsedTime = elapsedTime;
            ListTest = listTest;
        }
        public long ElapsedTime { get; set; }
        public List<KeyValuePair<int, short>> ListTest { get; set; }
    }
}
