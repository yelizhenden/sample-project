namespace Runner
{

    interface IRunnerService
    {
        void Run();
    }

    public class RunnerService : IRunnerService
    {
        private readonly IUserInterface _userInterface;
        private readonly RunnerCommandFactory _commandFactory;

        public RunnerService(IUserInterface userInterface, RunnerCommandFactory commandFactory)
        {
            _userInterface = userInterface;
            _commandFactory = commandFactory;
        }
        
        public void Run()
        {
            Greeting();

            var response = _commandFactory.GetCommand("?").RunCommand();

            while (!response.shouldQuit)
            {
                // look at this mistake with the ToLower()
                var input = _userInterface.ReadValue("> ").ToLower();
                var command = _commandFactory.GetCommand(input);

                response = command.RunCommand();

                if (!response.wasSuccessful)
                {
                    _userInterface.WriteMessage("Enter ? to view options.");
                }
            }
        }

        private void Greeting()
        {
            _userInterface.WriteMessage("*********************************");
            _userInterface.WriteMessage("* Welcome to Yeliz's Assignment *");
            _userInterface.WriteMessage("*********************************");
        }

    }

    class Program
    {
        private static void Main(string[] args)
        {
            IUserInterface userInterface = new ConsoleUserInterface();
            RunnerCommandFactory runnerCommandFactory = new RunnerCommandFactory(userInterface);
            IRunnerService runnerService = new RunnerService(userInterface, runnerCommandFactory);
            runnerService.Run();
        }

    }
}
