using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.BusinessLayer;
using Week7.Master.MVC.Helper;
using Week7.Master.MVC.Models;

namespace Week7.Master.MVC.Controllers
{
    public class DocentiController : Controller
    {
        private readonly IBusinessLayer BL;
        public DocentiController(IBusinessLayer BL)
        {
            this.BL = BL;
        }

        public IActionResult Index()
        {
            var docenti = BL.GetAllDocenti();
            List<DocenteViewModel> docentiViewModel = new List<DocenteViewModel>();
            foreach (var d in docenti)
            {
                docentiViewModel.Add(d.ToDocenteViewModel());
            }

            return View(docentiViewModel);
        }
    }
}
