using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contract
{
    public class UserProfile
    {
        public UserProfile(string nickName)
        {
            NickName = nickName;
        }
        public string NickName { get; set; }
    }
}
