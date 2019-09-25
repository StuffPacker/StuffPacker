using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Model
{
    public class ProductModel
    {
        private ProductEntity Entity;

        public ProductModel(ProductEntity entity)
        {
            Entity = entity;
        }

        public object Name => Entity.Name;

        public decimal Weight => Entity.Weight;

        public WeightPrefix WeightPrefix => Entity.WeightPrefix;

        public Guid Id => Entity.Id;
    }
}
