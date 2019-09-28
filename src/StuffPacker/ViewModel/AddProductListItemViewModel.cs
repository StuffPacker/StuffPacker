using System;

namespace StuffPacker.ViewModel
{
    public class AddProductListItemViewModel
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public bool Selected { get; set; }

        public bool IsNew { get; set; }
    }
}
