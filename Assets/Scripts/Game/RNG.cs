using System;
using System.Collections.Generic;

public class RNG
{
    // Private Random instance
    private static Random rng;

    // Optional: store the seed for reproducibility
    private static int seed;

    // Initialize RNG with an optional fixed seed
    public static void Init(int? fixedSeed = null)
    {
        if (fixedSeed.HasValue)
        {
            seed = fixedSeed.Value;
            rng = new Random(seed); // deterministic
        }
        else
        {
            seed = Environment.TickCount;
            rng = new Random(seed); // random
        }
    }

    // Expose the seed (useful for logging/replay)
    public static int Seed => seed;

    // Basic integer random [min, max)
    public static int Next(int min, int max)
    {
        return rng.Next(min, max);
    }

    // Float between 0 and 100
    public static float NextFloat()
    {
        return ((float)rng.NextDouble() * 100f);
    }

    // Boolean with given probability of true
    public static bool NextBool(float probability = 0.5f)
    {
        return NextFloat() < probability * 100f; // probability is 0–1
    }

    // Pick a random element from a list
    public static T NextChoice<T>(IList<T> list)
    {
        if (list == null || list.Count == 0)
            throw new ArgumentException("List cannot be null or empty");
        int index = rng.Next(0, list.Count);
        return list[index];
    }

    // Shuffle a list in-place (Fisher-Yates)
    public static void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = rng.Next(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
    
    /*
    public static Ingredient PickUniqueIngredient(List<Ingredient> list)
    {
        if (list == null || list.Count == 0) return null;
        int index = RNG.Next(0, list.Count);
        Ingredient choice = list[index];
        list.RemoveAt(index);
        return choice;
    }*/
}
