using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contract
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }

        string GetUserName();

        UserType GetUserType();
    }
}
