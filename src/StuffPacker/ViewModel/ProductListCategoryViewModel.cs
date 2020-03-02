using StuffPacker.ViewModel.Base;
using System;
using System.Collections.Generic;

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

        public List<ImageViewModel> Images { get; set; }
    }
}
