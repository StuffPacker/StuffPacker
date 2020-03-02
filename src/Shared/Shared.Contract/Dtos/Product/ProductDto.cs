using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contract.Dtos.Product
{
    public class ProductDto
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public IEnumerable<ProductImageDto> Images { get; set; }
    }
}
