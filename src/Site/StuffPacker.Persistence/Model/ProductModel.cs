using System;

namespace StuffPacker.Model
{
    public class ProductModel
    {
        public ProductEntity Entity;

        public ProductModel(ProductEntity entity)
        {
            Entity = entity;
        }

        public string Name => Entity.Name;

        public decimal Weight => Entity.Weight;

        public WeightPrefix WeightPrefix => Entity.WeightPrefix;

        public Guid Id => Entity.Id;

        public Guid? Owner => Entity.Owner;

        public void Update(string name)
        {
            Entity.Name = name;
        }

        public void Update(string name, decimal weight)
        {
            Entity.Name = name;
            Entity.Weight = weight;
        }
    }
}
