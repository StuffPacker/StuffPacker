using StuffPacker.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StuffPacker.Persistence.Model
{
    public class UserProfileModel
    {
        public UserProfileModel(UserProfileEntity entity)
        {
            Entity = entity;
        }
        public UserProfileEntity Entity{get;set;}
        public string NickName => Entity.NickName;
        public string FirstName => Entity.FirstName;
        public string LastName=>Entity.LastName;
    }
}
