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

        public DateTimeOffset Modified => Entity.Modified;

        public string Name => Entity.Name;

        public IEnumerable<PackListGroupModel> Groups => GetGroups();

        public WeightPrefix WeightPrefix => (WeightPrefix) Enum.Parse(typeof(WeightPrefix), Entity.WeightPrefix, true);

        public bool IsPublic => Entity.IsPublic;

        public Guid UserId => Entity.UserId;

        public bool Maximized => Entity.Maximized;

        public bool Visible => Entity.Visible;

        private IEnumerable<PackListGroupModel> GetGroups()
        {
            var groups = new List<PackListGroupModel>();
            if(string.IsNullOrEmpty(Entity.Groups))
            {
                return groups;
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<PackListGroupModel>>(Entity.Groups) ;

        }

        public void Update(string name,WeightPrefix weightPrefix,bool isPublic)
        {
            Entity.Name = name;
            Entity.WeightPrefix = weightPrefix.ToString();
            Entity.IsPublic = isPublic;
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

        public void UpdateVisible(bool visible)
        {
            Entity.Visible = visible;
        }

        public void UpdateMaximized(bool maximized)
        {
            Entity.Maximized = maximized;
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

        public void DeleteGroup(Guid groupId)
        {
            var all = (GetGroups().ToList());
            var g = all.First(x => x.Id == groupId);
            all.Remove(g);
            Entity.Groups = Newtonsoft.Json.JsonConvert.SerializeObject(all);
        }
    }
}
