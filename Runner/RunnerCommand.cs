namespace Runner
{
    public abstract class RunnerCommand
    {
        private readonly bool _isTerminatingCommand;
        protected IUserInterface Interface { get; }
        internal RunnerCommand(bool commandIsTerminating, IUserInterface userInterface)
        {
            _isTerminatingCommand = commandIsTerminating; 
            Interface = userInterface;
        }

        public (bool wasSuccessful, bool shouldQuit) RunCommand()
        {
            if (this is IParameterizedCommand parameterisedCommand)
            {
                var allParametersCompleted = false;

                while (allParametersCompleted == false)
                {
                    allParametersCompleted = parameterisedCommand.GetParameters();
                }
            }

            return (InternalCommand(), _isTerminatingCommand);
        }

        internal abstract bool InternalCommand();

        internal string GetParameter(string parameterName)
        {
            return Interface.ReadValue($"Enter {parameterName}: "); 
        }

    }

    public interface IParameterizedCommand
    {
        bool GetParameters();
    }
    internal abstract class NonTerminatingCommand : RunnerCommand
    {
        protected NonTerminatingCommand(IUserInterface userInterface) : base(commandIsTerminating: false, userInterface: userInterface){}
    }

    internal class QuitCommand : RunnerCommand
    {
        public QuitCommand(IUserInterface userInterface) : 
           base(commandIsTerminating: true, userInterface: userInterface)
           {}

        internal override bool InternalCommand()
        {
            Interface.WriteMessage("Quitting");
            
            return true;
        }

    }

    internal class HelpCommand : NonTerminatingCommand
    {
        internal HelpCommand(IUserInterface userInterface) : base(userInterface)
        {
        }
        internal override bool InternalCommand()
        {
            Interface.WriteMessage("USAGE:");
            Interface.WriteMessage("SequenceAnalysis (sa / sequenceanalysis)");
            Interface.WriteMessage("SumOfMultiple (som / sumofmultiple)");
            Interface.WriteMessage("quit (q)");
            Interface.WriteMessage("?");

            Interface.WriteMessage("EXAMPLES:");
            Interface.WriteMessage("Sum of Multiple Problem");
            Interface.WriteMessage("Find the sum of all natural numbers that are a multiple of 3 or 5 below a limit provided as input.");
            Interface.WriteMessage("> sumofmultiple");
            Interface.WriteMessage("Enter the limit number: 10");
            Interface.WriteMessage("Result: 23");

            Interface.WriteMessage("Sequence Analysis Problem");
            Interface.WriteMessage("Find the uppercase letters in a string, provided as input, and order all characters in these words alphabetically.");
            Interface.WriteMessage("> sequenceanalysis");
            Interface.WriteMessage("Enter the input string: This is a STRING");
            Interface.WriteMessage("Result: GINRSTT");

            Interface.WriteMessage("");
            return true;
        }
    }

    internal class UnknownCommand : NonTerminatingCommand
    { 
        internal UnknownCommand(IUserInterface userInterface) : base(userInterface)
        {
        }

        internal override bool InternalCommand()
        { 
            Interface.WriteWarning("Unable to determine the desired command."); 

            return false;
        }
    }
    internal class SequenceAnalysisCommand : NonTerminatingCommand, IParameterizedCommand
    {
        public SequenceAnalysisCommand(IUserInterface userInterface) : 
           base(userInterface)
           {}
        internal override bool InternalCommand()
        {
            try
            {
                string result = SequenceAnalysisLibrary.SequenceAnalysis.Analyze(InputString);
                Interface.WriteMessage($"Result: {result}");
                return true;
            }
            catch(Exception e)
            {
                Interface.WriteWarning(e.Message);
                return false;
            }
            
        }

        public string InputString { get; private set; }


        public bool GetParameters()
        {
            if (string.IsNullOrWhiteSpace(InputString))
                InputString = GetParameter("the input string");

            return !string.IsNullOrWhiteSpace(InputString);
        }    

    }

    internal class SumOfMultipleCommand : NonTerminatingCommand, IParameterizedCommand
    {
         public SumOfMultipleCommand(IUserInterface userInterface) : 
           base(userInterface)
           {}
        internal override bool InternalCommand()
        {
            try
            {
                int result = SumOfMultipleLibrary.SumOfMultiple.Solve(InputInteger);
                Interface.WriteMessage($"Result: {result}");
                return true;
            }
            catch(Exception e)
            {
                Interface.WriteWarning(e.Message);
                return false;
            }
            
        }

        private int _inputInteger;
        internal int InputInteger { get => _inputInteger; private set => _inputInteger = value; }

        public bool GetParameters()
        {
            if (InputInteger == 0)
                int.TryParse(GetParameter("the limit number"), out _inputInteger);

            return InputInteger != 0;
        }    
    }
    public class RunnerCommandFactory
    {
        private readonly IUserInterface _userInterface;
        public RunnerCommandFactory(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public RunnerCommand GetCommand(string input)
        {
            switch (input)
            {
                case "q":
                case "quit":
                    return new QuitCommand(_userInterface);
                case "sa":
                case "sequenceanalysis":
                    return new SequenceAnalysisCommand(_userInterface);
                case "som":
                case "sumofmultiple":
                    return new SumOfMultipleCommand(_userInterface);
                case "?":
                    return new HelpCommand(_userInterface);
                default:
                    return new UnknownCommand(_userInterface);
            }
        }
    }

}