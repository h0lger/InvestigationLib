using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvestigationLib.Threading;
using System.Diagnostics;

namespace TestInvestigations
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConcurrencyPerformace()
        {
            ConcurrencyPerformance p = new ConcurrencyPerformance();
            WritePerformanceTest(p.ExecListTest(), "ListTest");            
        }

        private static void WritePerformanceTest(long milliSec, string testName)
        {
            Debug.WriteLine(string.Format("{0} finished in {1} milliseconds.", testName, milliSec.ToString()));
        }
    }
}
