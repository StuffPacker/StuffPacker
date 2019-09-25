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

        public ProductEntity(Guid id)
        {
            Id = id;
        }
    }
}
