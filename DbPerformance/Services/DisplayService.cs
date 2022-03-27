using DbPerformance.Models;

namespace DbPerformance.Services;

public static class DisplayService
{
    public static void DisplayResult(PerformanceModel model)
    {
        Console.WriteLine("-------------------------------------------------------------------------------------------");
        Console.WriteLine($"-| {model.Name} \t | {model.Count}\t | {model.Time}ms\t | {DbServices.Count()} \t ");
    }
}