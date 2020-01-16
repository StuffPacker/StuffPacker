using StuffPacker;
using System;

namespace Shared.Contract.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public decimal Weight { get; set; }
        public WeightPrefix WeightPrefix { get; set; }

        public string Category { get; set; }

        public bool Star { get; set; }
        public bool Wearable { get; set; }
        public bool Consumables { get; set; }

        public string Description { get; set; }

        public ProductDto()
        {
            WeightPrefix = WeightPrefix.Gram;
            Amount = 1;
        }
        public string WeightAndToken => GetWeightAndToken();
        public string WeightAndTokenShort => GetWeightAndToken(true);
        public string GetWeightAndToken(bool shortToken = false)
        {
            return WeightHelper.GetRoundedWeight(Convert.ToDecimal(Weight), true, WeightPrefix, shortToken);
        }
        public int Amount { get; set; }



        public string ConvertedWeight => GetConvertedWeight();

        private string GetConvertedWeight()
        {
            return (WeightHelper.ConvertFromGram(Convert.ToDecimal(Weight), WeightPrefix)).ToString();
        }
    }
}
