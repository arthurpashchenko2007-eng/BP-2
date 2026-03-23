namespace MyLibrary;

public static class Generator
{
    public static IEnumerable<string> ColorCycleGenerator(string[] colors)
    {
        if (colors == null || colors.Length == 0) yield break;
        int index = 0;
        while (true)
        {
            yield return colors[index];
            index = (index + 1) % colors.Length;
        }
    }
}