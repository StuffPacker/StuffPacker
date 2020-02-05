using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contract.Dtos
{
    public class UpdateUserNamesDto
    {
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
