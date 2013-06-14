using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationLib.Threading
{
    public class ConcurrencyPerformance
    {
        #region Variables         
        private List<KeyValuePair<int, short>> _listTest = new List<KeyValuePair<int, short>>(30000);
        #endregion

        #region Properties
        protected List<KeyValuePair<int, short>> ListTest
        {
            get
            {
                return _listTest;
            }
        }
        #endregion

        #region Methods
        public PerformanceResult ExecListTest()
        {
            Action<object> a = new Action<object>(x => 
                {
                    short threadNo = short.Parse(x.ToString());
                    Debug.WriteLine("Start creation of 10k ints...");
                    //Add 10000 ints
                    for(int i = 0;i<10000;i++)
                    {
                        //Increase the next integer with 1
                        //To test reading/saving from multi threaded environment
                        if (ListTest.Count > 0)
                            ListTest.Add(new KeyValuePair<int, short>((ListTest[(ListTest.Count - 1)].Key + 1), threadNo));
                        else
                            ListTest.Add(new KeyValuePair<int,short>(i, threadNo));
                    }                    
                    Debug.WriteLine("Finished creation of 10k ints...");
                });
            Action b = new Action(() =>
            {
                Task t1 = new Task(a, 1);                
                Task t2 = new Task(a, 2);
                Task t3 = new Task(a, 3);
                t1.Start();
                t2.Start();
                t3.Start();
                t1.Wait();
                t2.Wait();
                t3.Wait();
                Debug.WriteLine("List count: " + ListTest.Count().ToString());
            });

            long elapsedTime = Utils.Utils.MeasureElapsedTime(b);            

            return new PerformanceResult(elapsedTime, ListTest);
        }
        #endregion        
    }
}
