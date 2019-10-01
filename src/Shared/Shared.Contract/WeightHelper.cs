using Shared.Contract;
using StuffPacker;
using System;

namespace Shared.Contract
{
    public static class WeightHelper
    {
        public static string GetRoundedWeight(decimal weight, bool withSufix, WeightPrefix weightPrefix)
        {

            weight = GetConvertedWeight(weight, weightPrefix);



            var sufix = string.Empty;
            if (withSufix)
            {
                sufix = " " + weightPrefix.ToString();
            }
            int value = Convert.ToInt32(@Math.Round(weight, 0));
            if (value > 0)
            {
                return value + sufix;
            }
            var value2 = Math.Round(weight, 2);
            if (value2 > Convert.ToDecimal(0))
            {
                if (value2 > Convert.ToDecimal(0))
                {
                    var sv = value2.ToString();
                    if (sv.EndsWith("0"))
                    {
                        sv = sv.Remove(sv.Length - 1);
                    }
                    return sv + sufix;
                }

            }
            if (weight > Convert.ToDecimal(0))
            {
                return Convert.ToDecimal(0.01).ToString() + sufix;
            }

            return "0" + sufix;

        }

        public static decimal ConvertFromGram(decimal weight, WeightPrefix weightPrefix)
        {
            return  GetConvertedWeight(weight, weightPrefix);
        }

        public static decimal ConvertToGram(decimal weight, WeightPrefix weightPrefix)
        {          
                    return WeightConverter.GetConvertedWeightToGram(weight,weightPrefix);
               
            
        }

        private static decimal GetConvertedWeight(decimal gram, WeightPrefix weightPrefix)
        {
            if (weightPrefix == WeightPrefix.Gram)
            {
                return gram;
            }
            switch (weightPrefix)
            {
                case WeightPrefix.none:
                    weightPrefix = WeightPrefix.Gram;
                    return gram;
                case WeightPrefix.Ounce:
                    return WeightConverter.GetConvertedWeight(gram, weightPrefix);
                case WeightPrefix.Pound:
                    return WeightConverter.GetConvertedWeight(gram, weightPrefix);
            }
            throw new Exception("Cant convert weight");
        }

    }
}
