using System;
using System.Collections.Generic;

namespace StuffPacker.Model
{
    public class PackListModel
    {
        public PackListEntity Entity;

        public PackListModel(PackListEntity entity)
        {
            Entity = entity;
        }
        public PackListModel(Guid id)
        {
            Entity = new PackListEntity(id);

        }

        public Guid Id => Entity.Id;

        public string Name => Entity.Name;

        public IEnumerable<PackListGroupModel> Groups => GetGroups();

        private IEnumerable<PackListGroupModel> GetGroups()
        {
            var groups = new List<PackListGroupModel>();
            if(string.IsNullOrEmpty(Entity.Groups))
            {
                return groups;
            }


            return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<PackListGroupModel>>(Entity.Groups) ;

        }

        public void Update(string name)
        {
            Entity.Name = name;
        }
    }
}
