using StuffPacker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Repositories
{
    public class IProductRepositoryFake: IProductRepository
    {
        private List<ProductEntity> List;

        public IProductRepositoryFake()
        {
            List = new List<ProductEntity>();
            var rnd2 = new Random();
            for (int i = 0; i < 10; i++)
            {
                var item = new ProductEntity(Guid.NewGuid());
                item.Name = "Product " + i;
                item.Weight = rnd2.Next(100, 2000);
                item.WeightPrefix = WeightPrefix.Gram;
                List.Add(item);                  
            }
        }

        public async Task<ProductModel> Get(Guid item)
        {
            await Task.Delay(30);
            var rnd = (new Random()).Next(1,8);
            return new ProductModel(List[rnd]);
        }
    }
}
