using System;

namespace Utilities
{
    public static class Utilities
    {
        private static Random _random = new Random();

        public static int RandomNumberInRange(int min, int max)
        {
            return _random.Next(min, max);
        }
        

        public static string IdGenerator(string type)
        {
            var id = type + RandomNumberInRange(10000, 99999).ToString();
            return id;
        }
        public static decimal RandomDecimalValueInRange(int min,int max,int round)
        {
            var temp = new decimal(_random.Next(min, max) + _random.NextDouble());
            return Math.Round(temp, round);
        }

    }
}
