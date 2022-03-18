using Microsoft.VisualStudio.TestTools.UnitTesting;
using Runner;


namespace RunnerTests;

[TestClass]
public class RunnerCommandFactoryTests
{
    [TestInitialize]
    public void Initialize()
    {
        var expectedInterface = new Helpers.TestUserInterface(
            new List<Tuple<string, string>>(),
            new List<string>(),
            new List<string>()
        ); 

        Factory = new RunnerCommandFactory(expectedInterface);
    }

    [TestMethod]
    public void QuitCommand_Successful()
    { 
        Assert.IsInstanceOfType(Factory.GetCommand("q"), typeof(QuitCommand), "q should be QuitCommand");
        Assert.IsInstanceOfType(Factory.GetCommand("quit"), typeof(QuitCommand), "quit should be QuitCommand");
    }

    [TestMethod]
    public void HelpCommand_Successful()
    {
        Assert.IsInstanceOfType(Factory.GetCommand("?"), typeof(HelpCommand), "? should be HelpCommand"); 
    }

    [TestMethod]
    public void UnknownCommand_Successful()
    {
        Assert.IsInstanceOfType(Factory.GetCommand("s"), typeof(UnknownCommand), 
                                                            "unmatched command should be UnknownCommand");
        Assert.IsInstanceOfType(Factory.GetCommand("summultiple"), typeof(UnknownCommand), 
                                                            "unmatched command should be UnknownCommand");
        Assert.IsInstanceOfType(Factory.GetCommand("h"), typeof(UnknownCommand), 
                                                            "unmatched command should be UnknownCommand");
        Assert.IsInstanceOfType(Factory.GetCommand("help"), typeof(UnknownCommand), 
                                                            "unmatched command should be UnknownCommand");
    }

    [TestMethod]
    public void SumOfMultipleCommand_Successful()
    {
        Assert.IsInstanceOfType(Factory.GetCommand("som"), 
                                typeof(SumOfMultipleCommand), 
                                "som should be SumOfMultipleCommand");
        Assert.IsInstanceOfType(Factory.GetCommand("sumofmultiple"), 
                                typeof(SumOfMultipleCommand), 
                                "sumofmultiple should be SumOfMultipleCommand_");
    }

    [TestMethod]
    public void SequenceAnalysisCommand_Successful()
    {
        Assert.IsInstanceOfType(Factory.GetCommand("sa"), 
                                typeof(SequenceAnalysisCommand), 
                                "sa should be SequenceAnalysisCommand");
        Assert.IsInstanceOfType(Factory.GetCommand("sequenceanalysis"), 
                                typeof(SequenceAnalysisCommand), 
                                "sequenceanalysis should be SequenceAnalysisCommand");
    }
    
    

    

}