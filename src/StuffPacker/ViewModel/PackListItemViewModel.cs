using Shared.Contract;
using System;

namespace StuffPacker.ViewModel
{
    public class PackListItemViewModel
    {
        public PackListItemViewModel()
        {
            WeightPrefix = WeightPrefix.Gram;
            Amount = 1;
        }
        public string WeightAndToken => GetWeightAndToken();
        public string GetWeightAndToken()
        {
            return WeightHelper.GetRoundedWeight(Convert.ToDecimal(Weight), true, WeightPrefix);
        }
        public int Amount { get; set; }

        public string Name { get; set; }

        public string ConvertedWeight => GetConvertedWeight();

        private string GetConvertedWeight()
        {
            return (WeightHelper.ConvertFromGram(Convert.ToDecimal(Weight), WeightPrefix)).ToString();
        }

        public string Weight { get; set; }

        public WeightPrefix WeightPrefix { get; set; }
        public Guid Id { get; set; }
    }
}
