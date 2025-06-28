using UnityEngine;
using Random = System.Random;

public static class RandomUtils
{
    private static readonly Random _random = new Random();

    private static float NextFloat()
    {
        return (float)_random.NextDouble();
    }

    public static bool ShouldSplit(int level)
    {
        var probability = 1f / Mathf.Pow(2f, level - 1);
        
        return NextFloat() < probability;
    }
}
