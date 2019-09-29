using System;
using System.Collections.Generic;

namespace StuffPacker.ViewModel
{
    public class PackListViewModel
    {
        public PackListViewModel()
        {
            WeightPrefix = WeightPrefix.Gram;
        }
        public string Name { get; set; }

        public Guid Id { get; set; }

        public decimal Weight => GetTotalWeight();

        private decimal GetTotalWeight()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total = total + item.Weight;
            }
            return total;
        }

        public IEnumerable<PackListGroupViewModel> Items { get; set; }

        public WeightPrefix WeightPrefix { get; set; }
    }
    public class PackListItemViewModel
    {
        public PackListItemViewModel()
        {
            WeightPrefix = WeightPrefix.Gram;
            Amount = 1;
        }

        public int Amount { get; set; }

        public string Name { get; set; }

        public string Weight { get; set; }

        public WeightPrefix WeightPrefix { get; set; }
        public Guid Id { get; set; }
    }
    public class PackListGroupViewModel
    {
        public string Name { get; set; }

        public Guid Id { get; set; }

        public decimal Weight => GetTotalWeight();

        public IEnumerable<PackListItemViewModel> Items { get; set; }

        private decimal GetTotalWeight()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total = total + (Convert.ToDecimal(item.Amount) * Convert.ToDecimal(item.Weight));
            }
            return total;
        }
        public string WeightAndToken => GetWaightAndToken();
        private string GetWaightAndToken()
        {
            return GetTotalWeight().ToString() + "g";
        }
    }
}
