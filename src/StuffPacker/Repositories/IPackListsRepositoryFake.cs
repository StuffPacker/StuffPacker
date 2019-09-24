using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StuffPacker.Model;

namespace StuffPacker.Repositories
{
    public class IPackListsRepositoryFake : IPackListsRepository
    {
        private List<PackListEntity> List;

        public IPackListsRepositoryFake()
        {
            List = new List<PackListEntity>();
            for (int i = 0; i < 5; i++)
            {
                List.Add(new PackListEntity(Guid.NewGuid()) { Groups=GetFakeGroups()});
            }
        }

        private string GetFakeGroups()
        {
            var list = new List<PackListGroupModel>();
            var grnd = (new Random()).Next(2, 5);

            var rnd2 = (new Random()).Next(2,6);
            var items = new List<Guid>();
            for (int i = 0; i < rnd2; i++)
            {
                items.Add(Guid.NewGuid());
            }

            for (int g = 0; g < grnd; g++)
            {
                list.Add(new PackListGroupModel { Name = "Group" + g,Items=items});
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(list);
        }

        public async Task<IEnumerable<PackListModel>> Get()
        {
            await Task.Delay(10);
            
            var list = new List<PackListModel>();
            foreach (var item in List)
            {
                list.Add(new PackListModel(item));
            }
            return list;
        }
    }
}
