using Shared.Contract;
using System;
using System.Collections.Generic;

namespace StuffPacker.ViewModel
{
    public class PackListViewModel
    {
        public PackListViewModel()
        {
            Items = new List<PackListGroupViewModel>();
        }
        public string Name { get; set; }

        public Guid UserId { get; set; }

        public bool IsPublic { get; set; }
        public Guid Id { get; set; }

        public DateTimeOffset Modified { get; set; }
        public decimal Weight => GetTotalWeight();

        public string WeightAndTokenShort => WeightAndToken(true);
        public string WeightAndToken(bool shortToken=false)
        {
            return WeightHelper.GetRoundedWeight(GetTotalWeight(), true, WeightPrefix,shortToken);
        }


        private decimal GetTotalWeight()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total = total + item.Weight;
            }
            return total;
        }


        public bool Maximized { get; set; }
        public bool Kit { get; set; }
        public IEnumerable<PackListGroupViewModel> Items { get; set; }

        public WeightPrefix WeightPrefix { get; set; }

        public bool Visible { get; set; }
    }


}
