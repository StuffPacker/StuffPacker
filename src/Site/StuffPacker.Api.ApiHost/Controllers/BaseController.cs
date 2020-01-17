using Microsoft.AspNetCore.Mvc;
using System;


namespace StuffPacker.Api.ApiHost.Controllers
{
    public class BaseController : Controller
    {
        public Guid GetUserId()
        {
            var id = User.FindFirst("CustomerId");
            return Guid.Parse(id.Value);
        }
    }
}
