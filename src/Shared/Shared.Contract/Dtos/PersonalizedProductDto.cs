using Shared.Contract.Dtos.Product;
using StuffPacker;
using System;

namespace Shared.Contract.Dtos
{
    public class PersonalizedProductDto:ProductDto
    {
       
        public WeightPrefix WeightPrefix { get; set; }

        public string Category { get; set; }

        public bool Star { get; set; }
        public bool Wearable { get; set; }
        public bool Consumables { get; set; }

        

        public PersonalizedProductDto()
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
