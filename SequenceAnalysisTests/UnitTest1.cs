using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceAnalysisLibrary;
namespace SequenceAnalysisTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
        public void TestMethod1()
        {
           string actual = "GIINRSSTT";
           string expected = SequenceAnalysis.Analyze("This IS a STRING");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string actual = string.Empty;
            string expected = SequenceAnalysis.Analyze(string.Empty);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string actual = string.Empty;
            string expected = SequenceAnalysis.Analyze("aaa");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string actual = "AAA";
            string expected = SequenceAnalysis.Analyze("AAA");

            Assert.AreEqual(expected, actual);
        }
}