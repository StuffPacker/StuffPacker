using System;
using System.Collections.Generic;
using System.Text;
using StuffPacker.Persistence.Entity;

namespace StuffPacker.Persistence.Model
{
    public class FriendModel
    {
        public FriendEntity Entity { get; set; }

        public Guid UserId => Entity.UserId;
        public Guid FriendUserId => Entity.FriendUserId;

        public FriendModel(FriendEntity entity)
        {
            Entity = entity;
        }
    }
}
