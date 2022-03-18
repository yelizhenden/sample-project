using Microsoft.VisualStudio.TestTools.UnitTesting;
using SumOfMultipleLibrary;

namespace SumOfMultipleTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
        public void TestMethod1()
        {
            int expected = SumOfMultiple.Solve(5);
            int actual = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int expected = SumOfMultiple.Solve(0);
            int actual = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int expected = SumOfMultiple.Solve(15); //3,5,6,9,10,12
            int actual = 45;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int expected = SumOfMultiple.Solve(int.MaxValue); //Overflow
            int actual = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int expected = SumOfMultiple.Solve(int.MinValue);
            int actual = 0;

            Assert.AreEqual(expected, actual);
        }
}