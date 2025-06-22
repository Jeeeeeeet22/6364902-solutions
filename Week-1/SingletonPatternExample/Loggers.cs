public class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new object();

    // Private constructor prevents instantiation from outside
    private Logger() {}

    // Public static method to get the singleton instance
    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new Logger();
            }
        }
        return _instance;
    }

    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}
