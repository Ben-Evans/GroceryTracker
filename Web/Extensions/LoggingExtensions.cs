using System.Diagnostics;
using ILogger = Serilog.ILogger;

namespace Web.Extensions;

public static class LoggingExtensions
{
    public static void LogCompletion(this ILogger logger, Func<object> func, string actionName)
    {
        logger.Information($"Starting {actionName}...");

        var timer = new Stopwatch();
        timer.Start();
        func();
        timer.Stop();

        logger.Information($"Completed {actionName} in {timer.ElapsedMilliseconds} ms.");
    }

    public static void LogCompletion(this ILogger logger, Action action, string? actionName = default)
    {
        actionName ??= action.Method.Name;

        logger.Information($"Starting {actionName}...");

        var timer = new Stopwatch();
        timer.Start();
        action();
        timer.Stop();

        logger.Information($"Completed {actionName} in {timer.ElapsedMilliseconds} ms.");
    }
}
