using StuffPacker.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StuffPacker.Persistence.Model
{
   public class FollowModel
    {
        public FollowEntity Entity { get; set; }
        public FollowModel(FollowEntity entity)
        {
            Entity = entity;
        }

        public Guid Id => Entity.Id;
        public Guid FollowUserId => Entity.FollowUserId;
        public Guid UserId => Entity.UserId;
    }
}
