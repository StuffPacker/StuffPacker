using StuffPacker;
using System;

namespace Shared.Contract.Dtos.PackList
{
    public class KitDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public WeightPrefix WeightPrefix { get; set; }
    }
}
