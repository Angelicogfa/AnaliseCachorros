using System;

namespace DogGenerator.Domain
{
    public static class DoubleExtensions
    {
        public static double NextDouble(this Random random, double min, double max)
        {
            return random.NextDouble() * (max - min) + max;
        }
    }
}

