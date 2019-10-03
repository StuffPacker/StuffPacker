using System;
using System.Threading.Tasks;

namespace StuffPacker.ViewModel
{
    public class ConfirmComponentViewModel
    {
        public ConfirmComponentViewModel()
        {
            OkButtonText = "Ok";
            OnOkClick = onOkClick;
            OnCancelClick = onCancelClick;
        }
        public bool DialogIsOpen { get; set; }
        public string Header { get; set; }

        public string OkButtonText { get; set; }

        public Func<Task<string>> OnOkClick { get; set; }

        public Func<Task<string>> OnCancelClick { get; set; }

        private async Task<string> onOkClick()
        {
            return string.Empty;
        }
        private async Task<string> onCancelClick()
        {
            return string.Empty;
        }
    }
}
