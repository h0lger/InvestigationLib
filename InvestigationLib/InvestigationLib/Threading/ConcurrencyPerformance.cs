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
        private HashSet<KeyValuePair<int, short>> _hashTest = new HashSet<KeyValuePair<int, short>>();
        #endregion

        #region Properties
        protected List<KeyValuePair<int, short>> ListTest
        {
            get
            {
                return _listTest;
            }
        }
        protected HashSet<KeyValuePair<int, short>> HashTest
        {
            get
            {
                return _hashTest;
            }
        }

        protected CollectionType CollType { get; set; }

        protected int CollectionCount
        {
            get
            {
                switch (CollType)
                {
                    case CollectionType.List:
                        return ListTest.Count;
                    case CollectionType.HashSet:
                        return HashTest.Count;
                    
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        #endregion

        #region Enums
        public enum CollectionType
        {
            Unknown = 0,
            List = 1,
            HashSet = 2
        }
        #endregion

        #region Methods
        public PerformanceResult ExecCollectionTest(CollectionType collectionType)
        {
            CollType = collectionType;
            Action<object> a = new Action<object>(x => 
                {
                    short threadNo = short.Parse(x.ToString());
                    Debug.WriteLine("Start creation of 10k ints...");
                    //Add 10000 ints
                    for(int i = 0;i<10000;i++)
                    {
                        //Increase the next integer with 1
                        //To test reading/saving from multi threaded environment
                        switch (collectionType)
                        {
                            case CollectionType.List:
                                if (ListTest.Count > 0)
                                    ListTest.Add(new KeyValuePair<int, short>((ListTest[(ListTest.Count - 1)].Key + 1), threadNo));
                                else
                                    ListTest.Add(new KeyValuePair<int, short>(i, threadNo));
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                        
                    }                    
                    Debug.WriteLine("Finished creation of 10k ints...");
                });
            Action b = new Action(() =>
            {
                Task[] tasks = new Task[3]
                {
                    Task.Factory.StartNew(a, 1),        
                    Task.Factory.StartNew(a, 2),
                    Task.Factory.StartNew(a, 3)
                };
                Task.WaitAll(tasks);
                Debug.WriteLine("List count: " + CollectionCount.ToString());
            });

            long elapsedTime = Utils.Utils.MeasureElapsedTime(b);            

            return new PerformanceResult(elapsedTime, ListTest);
        }        
        #endregion        
    }
}
