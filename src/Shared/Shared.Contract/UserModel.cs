using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contract
{
    public class UserModel
    {
        public string UserName { get; set; }

        public UserType UserType { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}
