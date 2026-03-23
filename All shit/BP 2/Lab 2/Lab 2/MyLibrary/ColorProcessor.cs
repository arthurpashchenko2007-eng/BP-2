using System.Diagnostics;

namespace MyLibrary;

public static class ColorProcessor
{
    public static void ConsumeWithTimeout(IEnumerable<string> iterator, int timeoutSeconds)
    {
        Stopwatch sw = Stopwatch.StartNew();
        int iteration = 0;
        foreach (var colorName in iterator)
        {
            if (sw.Elapsed.TotalSeconds >= timeoutSeconds) break;

            iteration++;
            if (Enum.TryParse(colorName, true, out ConsoleColor color))
                Console.ForegroundColor = color;

            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Iteration №{iteration}: {colorName}");
            Console.ResetColor();
            Thread.Sleep(200);
        }
        sw.Stop();
    }
}