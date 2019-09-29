using System;

namespace StuffPacker.ViewModel
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public decimal Weight { get;  set; }
        public WeightPrefix WeightPrefix { get;  set; }
    }
}
