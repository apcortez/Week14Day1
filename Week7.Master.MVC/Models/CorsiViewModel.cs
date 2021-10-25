using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week7.Master.MVC.Models
{
    public class CorsiViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
