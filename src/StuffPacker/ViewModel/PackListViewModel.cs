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

        public decimal Weight => GetTotalWeight();

        public string WeightAndToken()
        {
            return WeightHelper.GetRoundedWeight(GetTotalWeight(), true, WeightPrefix);
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



        public IEnumerable<PackListGroupViewModel> Items { get; set; }

        public WeightPrefix WeightPrefix { get; set; }
    }


}
