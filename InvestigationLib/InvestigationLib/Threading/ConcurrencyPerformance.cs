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
        private IList<int> _listTest = new List<int>(30000);
        #endregion

        #region Properties
        protected IList<int> ListTest
        {
            get
            {
                return _listTest;
            }
        }
        #endregion

        #region Methods
        public long ExecListTest()
        {
            Action a = new Action(() => 
                {
                    Debug.WriteLine("Start creation of 10k ints...");
                    //Add 10000 guids
                    for(int i = 0;i<10000;i++)
                    {
                        ListTest.Add(ListTest.Count + 1);
                    }                    
                    Debug.WriteLine("Finished creation of 10k ints...");
                });
            Action b = new Action(() =>
            {
                Task t1 = new Task(a);
                Task t2 = new Task(a);
                Task t3 = new Task(a);
                t1.Start();
                t2.Start();
                t3.Start();
                t1.Wait();
                t2.Wait();
                t3.Wait();
                Debug.WriteLine("List count: " + ListTest.Count().ToString());
            });

            return Utils.Utils.MeasureElapsedTime(b);         
        }
        #endregion        
    }
}
