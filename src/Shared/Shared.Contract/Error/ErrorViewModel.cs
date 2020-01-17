using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Contract.Error
{
    [Serializable]
    public class ErrorViewModel
    {
        public string Message { get; set; }
        public string Description { get; set; }
        public List<ErrorValidationViewModel> Errors { get; } = new List<ErrorValidationViewModel>();
        public bool HasErrors => Errors.Any();

        public void AddError(string field, string message)
        {
            Errors.Add(new ErrorValidationViewModel { Field = field, Message = message });
        }

        public override string ToString()
        {
            if (HasErrors)
            {
                return $"{Message} {Description} {string.Join(", ", Errors.Select(e => e.ToString()))}";
            }

            return string.Empty;
        }

        public static ErrorViewModel FromError(string field, string message)
        {
            var error = new ErrorViewModel();
            error.AddError(field, message);
            error.Message = message;
            return error;
        }
    }
}
