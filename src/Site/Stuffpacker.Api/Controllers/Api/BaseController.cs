using Microsoft.AspNetCore.Mvc;
using System;

namespace Stuffpacker.Api.Controllers.Api
{
   public class BaseController: Controller
    {
        public Guid GetUserId()
        {
            var id=User.FindFirst("CustomerId");
            return Guid.Parse(id.Value);
        }
    }
}
