using Shared.Contract;
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

        public string Description => Entity.Description;

        public decimal Weight => Entity.Weight;

        public WeightPrefix WeightPrefix => Entity.WeightPrefix;

        public Guid Id => Entity.Id;

        public Guid? Owner => Entity.Owner;

        public void Update(string name, decimal weight,WeightPrefix weightPrefix,string description)
        {
            Entity.Name = name;
            Entity.WeightPrefix = weightPrefix;
            if(weightPrefix!= WeightPrefix.Gram)
            {
                weight = WeightHelper.ConvertToGram(weight,weightPrefix);
            }
            Entity.Weight = weight;
            Entity.Description = description;
        }

       
    }
}
