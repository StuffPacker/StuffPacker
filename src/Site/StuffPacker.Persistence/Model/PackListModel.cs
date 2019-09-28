using System;
using System.Collections.Generic;
using System.Linq;

namespace StuffPacker.Model
{
    public class PackListModel
    {
        public PackListEntity Entity;

        public PackListModel(PackListEntity entity)
        {
            Entity = entity;
        }
        public PackListModel(Guid id,Guid userId)
        {
            Entity = new PackListEntity(id,userId);

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

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<PackListGroupModel>>(Entity.Groups) ;

        }

        public void Update(string name)
        {
            Entity.Name = name;
        }
        public void AddGroup(Guid id,string name)
        {
            var g = GetGroups().ToList();
            g.Add(new PackListGroupModel
            {
                Items = new List<Guid>(),
                Name = name,
                Id = id
            });
            Entity.Groups = Newtonsoft.Json.JsonConvert.SerializeObject(g);
        }

        public void AddGroupItem(Guid groupId,Guid productId)
        {
            var all = (GetGroups().ToList());
            var g = all.First(x=>x.Id==groupId);            
            var list = g.Items.ToList();
            list.Add(productId);
            g.Items = list;
            Entity.Groups = Newtonsoft.Json.JsonConvert.SerializeObject(all);
        }

        public void DeleteProductItem(Guid groupId, Guid productId)
        {
            var all = (GetGroups().ToList());
            var g = all.First(x => x.Id == groupId);
            var list = g.Items.ToList();
            list.Remove(productId);
            g.Items = list;
            Entity.Groups = Newtonsoft.Json.JsonConvert.SerializeObject(all);
        }

        public void UpdateGroup(Guid groupId,string name)
        {
            var all = (GetGroups().ToList());
            var g = all.First(x => x.Id == groupId);
            g.Name = name;
            Entity.Groups = Newtonsoft.Json.JsonConvert.SerializeObject(all);
        }
    }
}
