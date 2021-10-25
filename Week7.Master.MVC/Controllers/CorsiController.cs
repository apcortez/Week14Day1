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
    public class CorsiController : Controller
    {
        private readonly IBusinessLayer BL;
        public CorsiController(IBusinessLayer BL)
        {
            this.BL = BL;
        }

        //CRUD CORSO
        
        public IActionResult Index()
        {
           var corsi =  BL.GetAllCorsi();
            List<CorsoViewModel> corsiViewModel = new List<CorsoViewModel>();
            foreach(var c in corsi)
            {
                corsiViewModel.Add(c.toCorsoViewModel());
            }
          
            return View(corsiViewModel);
        }

        [HttpGet("Corsi/Details/{codice}")]
        public IActionResult Details(string codice)
        {
            var corso = BL.GetAllCorsi().Where(c => c.CorsoCodice == codice).FirstOrDefault();
            var corsoViewModel = corso.toCorsoViewModel();

            return View(corsoViewModel);
        }
    }
}
