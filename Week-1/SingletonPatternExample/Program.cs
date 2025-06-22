using System;

class Program
{
    static void Main()
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("This is the first log message.");
        logger2.Log("This is the second log message.");

        Console.WriteLine($"Are both loggers the same instance? {object.ReferenceEquals(logger1, logger2)}");
    }
}
