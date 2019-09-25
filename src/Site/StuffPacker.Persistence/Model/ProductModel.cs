using System;

namespace StuffPacker.Model
{
    public class ProductModel
    {
        private ProductEntity Entity;

        public ProductModel(ProductEntity entity)
        {
            Entity = entity;
        }

        public string Name => Entity.Name;

        public decimal Weight => Entity.Weight;

        public WeightPrefix WeightPrefix => Entity.WeightPrefix;

        public Guid Id => Entity.Id;
    }
}
