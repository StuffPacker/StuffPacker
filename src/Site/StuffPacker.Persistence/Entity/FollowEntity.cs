using System;
using System.Collections.Generic;
using System.Text;

namespace StuffPacker.Persistence.Entity
{
  public  class FollowEntity: SoftDeleteEntityBase
    {
      
        public Guid Id { get; set; }
        public Guid FollowUserId { get;  set; }
        public Guid UserId { get;  set; }
    }
}
