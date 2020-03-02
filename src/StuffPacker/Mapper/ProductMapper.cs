using Shared.Contract;
using Shared.Contract.Dtos.Product;
using StuffPacker.Model;
using StuffPacker.Persistence.Model;
using StuffPacker.Services;
using StuffPacker.ViewModel;
using StuffPacker.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Mapper
{
    public class ProductMapper : IProductMapper
    {
        private readonly ICurrentUser _currentUSer;
        private readonly ICdnHelper _cdnHelper;
        public ProductMapper(ICurrentUser currentUSer, ICdnHelper cdnHelper)
        {
            _currentUSer = currentUSer;
            _cdnHelper = cdnHelper;
        }

        public async Task<IEnumerable<AddProductListItemViewModel>> Map(IEnumerable<ProductModel> userProducts,IEnumerable<PersonalizedProductModel> personalizedProductModels, IEnumerable<PackListModel> kits)
        {
            var viewModels = new List<AddProductListItemViewModel>();
            userProducts = userProducts.OrderBy(x => x.Name).ToList();
            var curentUserId =  _currentUSer.GetUserId();
            foreach (var item in userProducts)
            {
                var pp = personalizedProductModels.FirstOrDefault(x => x.ProductId == item.Id && x.UserId == curentUserId);
                var category = "";
                if (pp != null)
                {
                    category = pp.Category;
                }
                viewModels.Add(new AddProductListItemViewModel(item.Id,item.Name,false,false,item.Weight,item.WeightPrefix, category,false));

            }
            foreach (var item in kits)
            {
                viewModels.Add(new AddProductListItemViewModel(item.Id,item.Name,false,false,0,item.WeightPrefix,"Kit",true));
            }
            return viewModels;
        }

        public async Task<ProductListCategoryViewModel> MapProductGroup(ProductGroupModel model)
        {
            return new ProductListCategoryViewModel
            {
                Maximized = model.Maximized,
                Name = model.Name,
                Id=model.Id
            };
        }

        public async Task<IEnumerable<ProductListCategoryViewModel>> MapProductGroups(IEnumerable<ProductGroupModel> productGroups)
        {
            var list = new List<ProductListCategoryViewModel>();
            foreach (var item in productGroups)
            {
                list.Add(await MapProductGroup(item));
            }
            return list;
        }

        public async Task<IEnumerable<ProductViewModel>> MapUserProducts(IEnumerable<ProductModel> products,IEnumerable<PersonalizedProductModel> personalizedProductModels)
        {
            var list = new List<ProductViewModel>();
            var curentUserId =  _currentUSer.GetUserId();
            foreach (var item in products)
            {
                var pp=personalizedProductModels.FirstOrDefault(x=>x.ProductId==item.Id && x.UserId== curentUserId);
                var category = "";
                var star = false;
                var consumables = false;
                var wearable = false;
                if (pp!=null)
                {
                    category= pp.Category;
                     star = pp.Star;
                     consumables = pp.Consumables;
                     wearable = pp.Wearable;
                }

                list.Add(new ProductViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Weight = item.Weight,
                    WeightPrefix = item.WeightPrefix,
                    Category = category,
                    Star = star,
                    Consumables = consumables,
                    Wearable = wearable,
                    Description = item.Description,
                    Images = GetImages(item.Images)
                }) ;
            }
            return list;
        }

        private List<ImageViewModel> GetImages(IEnumerable<ProductImageDto> images)
        {
            var list = new List<ImageViewModel>();
            foreach (var item in images)
            {
                list.Add(new ImageViewModel
                {
                    Url = _cdnHelper.GetPath(Enums.CdnFileType.ProductImage,item.FileName)
                }) ;
            }
            
                return list;
        }
    }
}
