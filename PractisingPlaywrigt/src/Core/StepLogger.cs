
using System.Diagnostics;
using AventStack.ExtentReports;

namespace PracticingPlaywright.src.Core;

public class StepLogger
{
    private readonly ExtentTest _test;

    public StepLogger(ExtentTest test)
    {
        _test = test;
    }

    public async Task RunAsync(
        string stepName,
        Func<ExtentTest, Task> action)
    {
        var step = _test.CreateNode(stepName);

        var start = DateTime.Now;
        var stopwatch = Stopwatch.StartNew();

        step.Info($"Start: {start:yyyy-MM-dd HH:mm:ss.fff}");

        try
        {
            await action(step);

            stopwatch.Stop();

            var end = DateTime.Now;

            step.Pass(
                            $"End: {end:yyyy-MM-dd HH:mm:ss.fff}<br>" +
                            $"Elapsed: {stopwatch.Elapsed.TotalSeconds:F3}s"
                        );
        }
        catch (Exception exception)
        {
            stopwatch.Stop();

            var end = DateTime.Now;

            step.Fail(
                $"End: {end:yyyy-MM-dd HH:mm:ss.fff}<br>" +
                $"Elapsed: {stopwatch.Elapsed.TotalSeconds:F3}s"
            );

            step.Fail(exception);

            throw;
        }
    }
}
