using Shared.Contract;
using System;

namespace StuffPacker.ViewModel
{
    public class AddProductListItemViewModel
    {
        public AddProductListItemViewModel(Guid id,string name,bool selected,bool isNew,decimal weight,WeightPrefix weightPrefix,string category,bool isKit)
        {
            Id = id;
            Name = name;
            Selected = selected;
            IsNew = isNew;
            Weight = weight;
            WeightPrefix = weightPrefix;
            Category = category;
            IsKit = isKit;
        }

        public string Name { get; set; }
        public Guid Id { get; set; }
        public bool Selected { get; set; }
        public bool IsNew { get; set; }

        public decimal Weight { get; set; }
        public string WeightAndToken => GetWeightAndToken();
        public bool IsKit { get; set; }

        public string Category { get; set; }

        public string GetWeightAndToken()
        {
            return WeightHelper.GetRoundedWeight(Convert.ToDecimal(Weight), true, WeightPrefix);

        }

        public WeightPrefix WeightPrefix { get; set; }
    }
}
