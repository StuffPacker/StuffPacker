using System;
using System.Collections.Generic;
using System.Text;

namespace StuffPacker.Persistence.Entity
{
    public class UserProfileEntity:SoftDeleteEntityBase
    {
        public Guid Id { get; set; }        
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}
