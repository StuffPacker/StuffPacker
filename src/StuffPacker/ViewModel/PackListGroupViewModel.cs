using Shared.Contract;
using System;
using System.Collections.Generic;

namespace StuffPacker.ViewModel
{
    public class PackListGroupViewModel
    {
        public string WeightAndToken => GetWeightAndToken();

        public string WeightAndTokenShort => GetWeightAndToken(true);
        public PackListGroupViewModel(WeightPrefix weightPrefix)
        {
            WeightPrefix = weightPrefix;
        }
        public string Name { get; set; }

        public string GetWeightAndToken(bool shortToken=false)
        {
            return WeightHelper.GetRoundedWeight(GetTotalWeight(), true, WeightPrefix,shortToken);
        }

        public Guid Id { get; set; }

        public decimal Weight => GetTotalWeight();

        public IEnumerable<ProductViewModel> Items { get; set; }

        public WeightPrefix WeightPrefix { get; set; }

        private decimal GetTotalWeight()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total = total + (Convert.ToDecimal(item.Amount) * Convert.ToDecimal(item.Weight));
            }
            return total;
        }

    }
}
