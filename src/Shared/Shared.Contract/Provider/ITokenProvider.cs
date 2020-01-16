using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contract.Provider
{
    public interface ITokenProvider
    {
        string GetToken(Guid id);
        void AddToken(Guid id, string token);
    }
}
