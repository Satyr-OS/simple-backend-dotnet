public class DatabaseConnectionFailed : Exception
{
    public DatabaseConnectionFailed() : base() { }

    public DatabaseConnectionFailed(string message) : base(message) { }

    public DatabaseConnectionFailed(string message, Exception innerException) : base(message, innerException) { }
}