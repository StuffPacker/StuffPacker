using System;

namespace StuffPacker.ViewModel
{
    public class ProductListCategoryViewModel
    {
        public ProductListCategoryViewModel()
        {
            Maximized = true;
        }
        public string Name { get; set; }
        public bool Maximized { get; set; }
        public Guid Id { get; set; }
    }
}
