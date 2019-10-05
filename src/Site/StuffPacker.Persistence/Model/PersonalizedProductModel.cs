using StuffPacker.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StuffPacker.Persistence.Model
{
    public class PersonalizedProductModel
    {
        public PersonalizedProductEntity Entity;

        public PersonalizedProductModel(PersonalizedProductEntity entity)
        {
            Entity = entity;
        }
        public PersonalizedProductModel(Guid id, Guid userId,Guid productId)
        {
            Entity = new PersonalizedProductEntity(id, userId, productId);

        }

        public Guid Id => Entity.Id;

        public string Category => Entity.Category;

        public Guid ProductId => Entity.ProductId;

        public Guid UserId => Entity.UserId;

        public void Update(string category)
        {
            Entity.Category = category;
        }
    }
}
