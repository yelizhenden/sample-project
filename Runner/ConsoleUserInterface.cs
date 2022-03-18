namespace Runner
{
    public interface IUserInterface : IReadUserInterface, IWriteUserInterface { }

    public interface IReadUserInterface
    {
        string ReadValue(string message);
    }

    public interface IWriteUserInterface
    {
        void WriteMessage(string message);
        void WriteWarning(string message);
    }
    public class ConsoleUserInterface : IUserInterface
    {
        // read value from console
        public string ReadValue(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            return Console.ReadLine();
        }

        // message to the console
        public void WriteMessage(string message)
        {   
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }

        // writer warning message to the console
        public void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
        }
    }
}