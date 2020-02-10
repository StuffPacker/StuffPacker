using Shared.Contract.Dtos.PackList;
using StuffPacker;
using System;
using System.Collections.Generic;

namespace Shared.Contract.Dtos
{

    public class PackListGroupDto
    {
        public string WeightAndToken => GetWeightAndToken();

        public string WeightAndTokenShort => GetWeightAndToken(true);
        public PackListGroupDto(WeightPrefix weightPrefix)
        {
            WeightPrefix = weightPrefix;
        }
        public string Name { get; set; }

        public string GetWeightAndToken(bool shortToken = false)
        {
            return WeightHelper.GetRoundedWeight(GetTotalWeight(), true, WeightPrefix, shortToken);
        }

        public Guid Id { get; set; }

        public decimal Weight => GetTotalWeight();

        public IEnumerable<ProductDto> Items { get; set; }

        public WeightPrefix WeightPrefix { get; set; }
        public IEnumerable<KitDto> Kits { get; set; }

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
