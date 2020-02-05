using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contract
{
    public class UserProfile
    {
        public UserProfile(string nickName,string firstName,string lastName,string userImgPath)
        {
            NickName = nickName;
            FirstName = firstName;
            LastName = lastName;
            UserImgPath = userImgPath;
        }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string UserImgPath { get; set; }
        public string LastName { get; set; }
    }
}
