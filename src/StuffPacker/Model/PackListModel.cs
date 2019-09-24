using System;
using System.Collections.Generic;

namespace StuffPacker.Model
{
    public class PackListModel
    {
        private PackListEntity Entity;

        public PackListModel(PackListEntity entity)
        {
            Entity = entity;
        }

        public Guid Id => Entity.Id;

        public IEnumerable<PackListGroupModel> Groups => Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<PackListGroupModel>>(Entity.Groups);
    }
}
