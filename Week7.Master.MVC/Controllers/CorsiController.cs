using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week7.Master.MVC.Controllers
{
    public class CorsiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
