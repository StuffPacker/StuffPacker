using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stuffpacker.Api.Controllers
{
   public class HomeController:Controller
    {
        public ActionResult Index()
        {
            return Content("Stuff packer Api");
        }
    }
}
