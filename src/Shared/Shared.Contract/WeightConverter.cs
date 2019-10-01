using StuffPacker;
using System;

namespace Shared.Contract
{
    public static class WeightConverter
    {
        public static decimal GetConvertedWeight(decimal input, WeightPrefix weightPrefix)
        {
            switch (weightPrefix)
            {
                case WeightPrefix.Gram:
                    return input;
                case WeightPrefix.Ounce:
                    return GetOunceFromGram(input);
                case WeightPrefix.Pound:
                    return GetPoundFromGram(input);

            }
            throw new Exception("Cant convert weight");
        }


        private static decimal GetPoundFromGram(decimal input)
        {
            return input * Convert.ToDecimal(0.00220462262185);
        }

        private static decimal GetOunceFromGram(decimal input)
        {
            return input * Convert.ToDecimal(0.035274);
        }

        public static decimal GetConvertedWeightToGram(decimal input, WeightPrefix weightPrefix)
        {
            switch (weightPrefix)
            {
                case WeightPrefix.Gram:
                    return input;
                case WeightPrefix.Ounce:
                    return GetGramFromOunce(input);
                case WeightPrefix.Pound:
                    return GetGramFromPound(input);

            }
            throw new Exception("Cant convert weight");
        }

        private static decimal GetGramFromPound(decimal input)
        {
            return input * Convert.ToDecimal(453.59237);
        }

        private static decimal GetGramFromOunce(decimal input)
        {
            return input * Convert.ToDecimal(28.34952);
        }
    }
}
