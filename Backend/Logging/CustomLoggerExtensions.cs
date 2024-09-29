namespace Backend.Logging;

public static class CustomLoggerExtensions
{
    public static ILoggingBuilder AddCustomLogger(this ILoggingBuilder builder) =>    
        builder.AddProvider(new CustomLoggerProvider());    
}
