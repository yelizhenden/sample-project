using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace RunnerTests
{
        [TestClass]
        public class UnknownCommandTests
        {
            [TestMethod]
            public void UnknownCommand_Successful()
            {
                var expectedInterface = new Helpers.TestUserInterface(
                    new List<Tuple<string, string>>(),
                    new List<string>(),
                    new List<string>
                    {
                        "Unable to determine the desired command."
                    }
                ); 

                var command = new UnknownCommand(expectedInterface);
                    
                var result = command.RunCommand();

                Assert.IsFalse(result.shouldQuit, "Unknown is not a terminating command.");
                Assert.IsFalse(result.wasSuccessful, "Unknown should not complete Successfully.");
            }
        }

        [TestClass]
        public class SumOfMultipleCommandTests
        {
            [TestMethod]
            public void SumOfMultipleCommand_Successful()
            {
                const string expectedLimitNumber = "15";
                var expectedInterface = new Helpers.TestUserInterface(
                    new List<Tuple<string, string>>
                    {
                        new Tuple<string, string>("Enter the limit number: ", expectedLimitNumber)
                    },
                    new List<string>(),
                    new List<string>()
                );

                var command = new SumOfMultipleCommand(expectedInterface);  

                var result = command.RunCommand();

                Assert.IsFalse(result.shouldQuit, "SumOfMultiple is not a terminating command.");
                Assert.IsTrue(result.wasSuccessful, "SumOfMultiple did not complete Successfully.");            
                
            }
        }

        [TestClass]
        public class SequenceAnalysisCommandTests
        {
            [TestMethod]
            public void SequenceAnalysisCommand_Successful()
            {
                const string expectedString = "XYyyDAaBbbbCMnDE";
                var expectedInterface = new Helpers.TestUserInterface(
                    new List<Tuple<string, string>>
                    {
                        new Tuple<string, string>("Enter the input string: ", expectedString)
                    },
                    new List<string>(),
                    new List<string>()
                );

                var command = new SequenceAnalysisCommand(expectedInterface);  

                var result = command.RunCommand();

                Assert.IsFalse(result.shouldQuit, "SequenceAnalysis is not a terminating command.");
                Assert.IsTrue(result.wasSuccessful, "SequenceAnalysis did not complete Successfully.");            
                
            }
        }
}
