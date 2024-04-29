
namespace Scheduler
{
    public static class Logger
    {
        public static void LogMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("INFO - {0} - {1}", DateTime.Now, message);
        }

        public static void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("WARNING - {0} - {1}", DateTime.Now, message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR - {0} - {1}", DateTime.Now, message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
