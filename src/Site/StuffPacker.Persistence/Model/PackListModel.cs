﻿using System;
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

        public bool Kit => Entity.Kit;

        private IEnumerable<PackListGroupModel> GetGroups()
        {
            var groups = new List<PackListGroupModel>();
            if(string.IsNullOrEmpty(Entity.Groups))
            {
                return groups;
            }
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<PackListGroupModel>>(Entity.Groups);
            }
            catch (Exception)
            {
                var gs= Newtonsoft.Json.JsonConvert.DeserializeObject<List<OldPackListGroupModel>>(Entity.Groups);
                var list = new List<PackListGroupModel>();
                foreach (var item in gs)
                {
                    var items = new List<PackListGroupItemModel>();
                    foreach (var i in item.Items)
                    {
                        items.Add(new PackListGroupItemModel { Id=i,IsKit=false});
                    }
                    list.Add(new PackListGroupModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Items = items
                    }
                        ) ;
                }
                return list;

            }
            

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
                Items = new List<PackListGroupItemModel>(),
                Name = name,
                Id = id
            });
            Entity.Groups = Newtonsoft.Json.JsonConvert.SerializeObject(g);
        }

        public void UpdateKit(bool kit)
        {
            Entity.Kit = kit;
        }

        public void AddGroupItem(Guid groupId,Guid productId,bool isKit)
        {
            var all = (GetGroups().ToList());
            var g = all.First(x=>x.Id==groupId);            
            var list = g.Items.ToList();
            list.Add(new PackListGroupItemModel { Id=productId,IsKit=isKit});
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
            var item = list.First(x=>x.Id==productId);
            list.Remove(item);
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
