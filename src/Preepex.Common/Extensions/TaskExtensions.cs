using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Preepex.Common.Extensions;

public static class TaskExtensions
{
    public static async Task LogAndExecuteAsync(this Task task, string functionName = "Unknown")
    {
        Stopwatch stopwatch = new Stopwatch();
        
        Console.WriteLine($"[LogAndExecuteAsync] {functionName} started at {DateTime.Now}");
        stopwatch.Start();
        
        await task;
        
        stopwatch.Stop();
        Console.WriteLine($"[LogAndExecuteAsync] {functionName} ended at {DateTime.Now}. Elapsed Time: {stopwatch.Elapsed.TotalSeconds} seconds");
    }

    public static async Task<T> LogAndExecuteAsync<T>(this Task<T> task, string functionName = "Unknown")
    {
        Stopwatch stopwatch = new Stopwatch();
        
        Console.WriteLine($"[LogAndExecuteAsync] {functionName} started at {DateTime.Now}");
        stopwatch.Start();
        
        T result = await task;
        
        stopwatch.Stop();
        Console.WriteLine($"[LogAndExecuteAsync] {functionName} ended at {DateTime.Now}. Elapsed Time: {stopwatch.Elapsed.TotalSeconds} seconds");
        
        return result;
    }
}