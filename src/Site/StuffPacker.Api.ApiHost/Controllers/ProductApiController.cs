using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Contract.Dtos;
using Shared.Contract.Dtos.PackList;
using Shared.Contract.Dtos.Product;
using StuffPacker.Api.ApiHost.Services;
using System;
using System.Threading.Tasks;


namespace StuffPacker.Api.ApiHost.Controllers
{
    [Authorize(AuthenticationSchemes = "ApiBearer")]
    [Route("api/v1/profile")]
    public class ProductApiController: BaseController
    {
        private readonly IProductService _productService;
        public ProductApiController(IProductService productService)
        {
            _productService = productService;
        }

       
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var product=await _productService.Get(productId);
            return Ok(product);
        }
    }
}
