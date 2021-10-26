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

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {
                var corso = corsoViewModel.toCorso();
                BL.InserisciNuovoCorso(corso);
                return RedirectToAction(nameof(Index));
            }

            return View(corsoViewModel);
        }

        [HttpGet("Corsi/Update/{codice}")]
        public IActionResult Update(string codice)
        {
            var corso = BL.GetAllCorsi().Where(c => c.CorsoCodice == codice).FirstOrDefault();
            var corsoViewModel = corso.toCorsoViewModel();

            return View(corsoViewModel);
        }

        [HttpPost("Corsi/Update/{codice}")]
        public IActionResult Update(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {
                var corso = corsoViewModel.toCorso();
                BL.ModificaCorso(corso.CorsoCodice, corso.Nome, corso.Descrizione);
                return RedirectToAction(nameof(Index));
            }
            return View(corsoViewModel);
        }


        [HttpGet]
        public IActionResult Delete(string id)
        {
            var corso = BL.GetAllCorsi().FirstOrDefault(c => c.CorsoCodice == id);
            var corsoViewModel = corso.toCorsoViewModel();
            return View(corsoViewModel);
        }

        [HttpPost]
        public IActionResult Delete(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {

                var corso = corsoViewModel.toCorso();
                BL.EliminaCorso(corso.CorsoCodice);
                return RedirectToAction(nameof(Index));

            }
            return View(corsoViewModel);
        }
    }
}
