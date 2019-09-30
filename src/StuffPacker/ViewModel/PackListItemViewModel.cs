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

        public int Amount { get; set; }

        public string Name { get; set; }

        public string Weight { get; set; }

        public WeightPrefix WeightPrefix { get; set; }
        public Guid Id { get; set; }
    }
}
