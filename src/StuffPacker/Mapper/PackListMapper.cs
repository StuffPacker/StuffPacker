using Shared.Contract.Dtos;
using Shared.Contract.Dtos.PackList;
using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;

namespace StuffPacker.Mapper
{
    public class PackListMapper : IPackListMapper
    {
        public IEnumerable<PackListViewModel> Map(IEnumerable<PackListDto> packLists)
        {
            var list = new List<PackListViewModel>();
            foreach (var item in packLists)
            {
                list.Add(Map(item));
            }
            return list;
        }

        public PackListViewModel Map(PackListDto dto)
        {
            return new PackListViewModel
            {
                Id = dto.Id,
                IsPublic = dto.IsPublic,
                Name = dto.Name,
                Modified = dto.Modified,
                UserId = dto.UserId,
                WeightPrefix = dto.WeightPrefix,
                Items = GetItems(dto.Items),
                Maximized = dto.Maximized,
                Visible = dto.Visible,
                Kit = dto.Kit
            };
        }

        private IEnumerable<PackListGroupViewModel> GetItems(IEnumerable<PackListGroupDto> items)
        {
            var list = new List<PackListGroupViewModel>();
            foreach (var item in items)
            {
                list.Add(new PackListGroupViewModel(item.WeightPrefix)
                {
                    Id = item.Id,
                    Name = item.Name,
                    WeightPrefix = item.WeightPrefix,
                    Items = GetProducts(item.Items,item.Kits)
                });
            }
            return list;
        }

        private IEnumerable<ProductViewModel> GetProducts(IEnumerable<ProductDto> items,IEnumerable<KitDto> kits)
        {
            var list = new List<ProductViewModel>();
            foreach (var item in items)
            {
                list.Add(new ProductViewModel
                {
                    Amount=item.Amount,
                    Category=item.Category,
                    Consumables=item.Consumables,                   
                    Description=item.Description,
                    Id=item.Id,
                    Name=item.Name,
                    Star=item.Star,
                    Wearable=item.Wearable,
                    Weight=item.Weight,
                    WeightPrefix=item.WeightPrefix                    
                });
            }
            foreach (var item in kits)
            {
                list.Add(new ProductViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = "Kit",
                    Amount = 1,
                    Weight = item.Weight,
                    WeightPrefix = item.WeightPrefix,
                    IsKit = true
                }) ;
            }
            return list;
        }
    }
}
