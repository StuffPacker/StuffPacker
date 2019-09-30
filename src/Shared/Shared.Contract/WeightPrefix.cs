using System.Collections.Generic;

namespace StuffPacker
{
    public enum WeightPrefix
    {
        none = 0,
        Gram,
        Ounce,
        Pound
    }
    public static class WeightPrefixHelper
    {
        public static List<string> GetWeightPrefix()
        {
            return new List<string>
            {
                WeightPrefix.Gram.ToString(),
                WeightPrefix.Pound.ToString(),
                WeightPrefix.Ounce.ToString()
            };
        }
    }

}
