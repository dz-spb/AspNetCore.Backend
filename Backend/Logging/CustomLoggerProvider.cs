namespace Backend.Logging;

internal class CustomLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName) =>
        new CustomLogger();

    public void Dispose()
    {
    }
}
