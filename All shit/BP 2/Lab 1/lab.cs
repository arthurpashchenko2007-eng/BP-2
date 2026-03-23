using System.Diagnostics;


public class Program
{
    public static IEnumerable<string> ColorCycleGenerator(string[] colors)
    {
        int index = 0;
        while (true)
        {
            yield return colors[index];
            index = (index + 1) % colors.Length;
        }
    }

    public static void ConsumeWithTimeout(IEnumerable<string> iterator, int timeoutSeconds)
    {
        Stopwatch sw = Stopwatch.StartNew();
        int iteration = 0;
        foreach (var colorName in iterator)
        {
            if (sw.Elapsed.TotalSeconds >= timeoutSeconds)
                break;

            iteration++;
            if (Enum.TryParse(colorName, true, out ConsoleColor color))
            {
                Console.ForegroundColor = color;
            }

            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Iteration №{iteration}: {colorName}");
            Console.ResetColor();

            Thread.Sleep(200); 
        }

        sw.Stop();
    }

    public static void Main()
    {
        string[] myColors = { "Red", "Green", "Blue", "Yellow", "Cyan", "Magenta" };
        var colorIterator = ColorCycleGenerator(myColors);
        ConsumeWithTimeout(colorIterator, 3);
    }
}