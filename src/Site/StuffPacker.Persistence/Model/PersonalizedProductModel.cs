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


        public bool Star => Entity.Star;
        public bool Consumables => Entity.Consumables;
        public bool Wearable => Entity.Wearable;





        public void Update(string category, bool star, bool wearable, bool consumables)
        {
            Entity.Category = category;
            Entity.Star = star;
            Entity.Wearable = wearable;
            Entity.Consumables = consumables;
        }
    }
}
