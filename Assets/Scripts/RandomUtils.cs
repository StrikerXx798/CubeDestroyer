using System.Collections.Generic;
using Random = System.Random;

static class RandomUtils
{
    private static readonly Random _random = new Random();
    private static readonly List<bool> _boolVariants = new List<bool>() { true };

    public static int Next(int minValue, int maxValue)
    {
        return _random.Next(minValue, maxValue);
    }

    public static bool NextBool()
    {
        var index = _random.Next(0, _boolVariants.Count);
        var newCount = _boolVariants.Count * 2;
        var variant = _boolVariants[index];

        while (_boolVariants.Count != newCount)
            _boolVariants.Add(false);

        return variant;
    }
}
