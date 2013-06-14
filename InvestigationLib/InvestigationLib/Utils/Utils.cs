using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationLib.Utils
{
    public class Utils
    {
        #region Static methods
        public static long MeasureElapsedTime(Action a)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            a.Invoke();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
        #endregion
    }
}
