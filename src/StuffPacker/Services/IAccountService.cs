using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
   public interface IAccountService
    {
        Task<bool> Login(string email,string password,bool rememberMe);
    }
}
