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
            PerformanceResult result = p.ExecListTest();
            Assert.AreEqual(30000, result.ListTest.Count);
            WritePerformanceTest(result.ElapsedTime, "ListTest");
            
        }

        private static void WritePerformanceTest(long milliSec, string testName)
        {
            Debug.WriteLine(string.Format("{0} finished in {1} milliseconds.", testName, milliSec.ToString()));
        }
    }
}
