using System;
using System.Threading.Tasks;

namespace StuffPacker.ViewModel
{
    public class ProductUpdateComponentViewModel
    {
        public ProductUpdateComponentViewModel()
        {
            ProductModel = new ProductViewModel();
            OnAfterOkClick = onAfterOkClick;
        }
        public bool DialogIsOpen { get; set; }

        public ProductViewModel ProductModel { get; set; }

        public bool EditMode { get; set; }

        public string ConvertedWeight { get; set; }

        public string WeightPrefixValue { get; set; }

        



        public Func<Task<string>> OnAfterOkClick { get; set; }

        private async Task<string> onAfterOkClick()
        {
            return string.Empty;
        }
    }
}
