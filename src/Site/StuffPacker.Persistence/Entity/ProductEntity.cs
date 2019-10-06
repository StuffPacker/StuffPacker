using StuffPacker.Persistence.Entity;
using System;

namespace StuffPacker.Model
{
    public class ProductEntity : SoftDeleteEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public WeightPrefix WeightPrefix { get; set; }

        public Guid? Owner { get; set; }
        public string Description { get; set; }

        public ProductEntity(Guid id,Guid? owner)
        {
            Id = id;
            WeightPrefix = WeightPrefix.Gram;
            Owner = owner;
        }
    }
}
