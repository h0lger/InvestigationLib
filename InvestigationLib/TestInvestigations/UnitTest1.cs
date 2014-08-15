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
            PerformanceResult result = p.ExecCollectionTest(ConcurrencyPerformance.CollectionType.List);
            Assert.AreEqual(30000, result.ListTest.Count);
            WritePerformanceTest(result.ElapsedTime, "ListTest");
            
        }

        [TestMethod]
        public void TestInterface()
        {
            IMain main = new ClassA();
            var a = main as ClassA;
            a.MyHash = new System.Collections.Generic.HashSet<Guid>();
        }

        private static void WritePerformanceTest(long milliSec, string testName)
        {
            Debug.WriteLine(string.Format("{0} finished in {1} milliseconds.", testName, milliSec.ToString()));
        }
    }
}
