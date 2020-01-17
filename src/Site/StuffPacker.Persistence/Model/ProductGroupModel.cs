using StuffPacker.Persistence.Entity;
using System;

namespace StuffPacker.Persistence.Model
{
    public class ProductGroupModel
    {
        public ProductGroupEntity Entity;

        public ProductGroupModel(ProductGroupEntity entity)
        {
            this.Entity = entity;
        }

        public bool Maximized => Entity.Maximized;
        public string Name => Entity.Name;

        public Guid Id => Entity.Id;
    }
}
