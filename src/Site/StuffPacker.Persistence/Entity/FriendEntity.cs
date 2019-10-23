using System;
using System.Collections.Generic;
using System.Text;

namespace StuffPacker.Persistence.Entity
{
   public class FriendEntity: SoftDeleteEntityBase
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public Guid FriendUserId { get; set; }
    }
}
