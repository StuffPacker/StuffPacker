using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contract.Error
{
    [Serializable]
    public class ErrorValidationViewModel
    {
        public string Field { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return $"{nameof(Field)}: {Field}, {nameof(Message)}: {Message}";
        }
    }
}
