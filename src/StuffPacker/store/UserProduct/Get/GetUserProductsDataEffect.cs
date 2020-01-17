using Blazor.Fluxor;
using Microsoft.Extensions.Logging;
using Shared.Contract;
using StuffPacker.Services;
using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.store.UserProduct.Get
{

    public class GetUserProductsDataEffect : Effect<GetUserProductsDataAction>
    {
        private readonly IProductService _productService;

        private readonly ICurrentUser _currentUser;

        private readonly ILogger<GetUserProductsDataEffect> _logger;

        public GetUserProductsDataEffect(IProductService productService, ICurrentUser currentUser, ILogger<GetUserProductsDataEffect> logger)
        {
            _productService = productService;
            _currentUser = currentUser;
            _logger = logger;
        }

        protected async override Task HandleAsync(GetUserProductsDataAction action, IDispatcher dispatcher)
        {
            try
            {

                var userId = _currentUser.GetUserId();
                var productGroups = (await _productService.GetProductGroups()).ToList();
                var products = await this._productService.GetById();
                var removeItems = new List<ProductListCategoryViewModel>();
                try
                {
                    foreach (var item in productGroups)
                    {
                        var hasProducts = products.FirstOrDefault(x => x.Category.ToLower() == item.Name.ToLower());
                        if (hasProducts == null)
                        {
                             await _productService.DeleteProductGroup(item.Id);
                            removeItems.Add(item);
                        }
                    }
                    foreach (var item in removeItems)
                    {
                        productGroups.Remove(item);
                    }
                   
                }
                catch (Exception e)
                {

                    _logger.LogError(e.ToString());
                }
             
                
                
                
                
                productGroups.Add(new ProductListCategoryViewModel { Name = "" });
                var categoryList = (productGroups).ToList();
                var productList = (products).ToList();
                dispatcher.Dispatch(new GetUserProductsDataSuccessAction(productList, categoryList));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new GetUserProductsDataFailedAction(errorMessage: e.Message));
            }
        }


    }
}
