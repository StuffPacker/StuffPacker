using System;
using System.Collections.Generic;
using System.Text;

namespace StuffPacker.Persistence.Entity
{
    public class PersonalizedProductEntity: SoftDeleteEntityBase
    {
        public PersonalizedProductEntity(Guid id,Guid userId,Guid productId)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        public string Category { get; set; }
    }
}
