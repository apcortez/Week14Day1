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

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var docente = docenteViewModel.toDocente();
                BL.InserisciNuovoDocente(docente);
                return RedirectToAction(nameof(Index));
            }

            return View(docenteViewModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var docente = BL.GetAllDocenti().Where(d => d.ID == id).FirstOrDefault();
            var docenteViewModel = docente.ToDocenteViewModel();

            return View(docenteViewModel);
        }

        [HttpPost]
        public IActionResult Update(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var docente = docenteViewModel.toDocente();
                BL.ModificaDocente(docente.ID, docente.Telefono, docente.Email);
                return RedirectToAction(nameof(Index));
            }
            return View(docenteViewModel);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var docente = BL.GetAllDocenti().Where(d => d.ID == id).FirstOrDefault();
            var docenteViewModel = docente.ToDocenteViewModel();
            return View(docenteViewModel);
        }

        [HttpPost]
        public IActionResult Delete(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {

                var docente = docenteViewModel.toDocente();
                BL.EliminaDocente(docente.ID);
                return RedirectToAction(nameof(Index));

            }
            return View(docenteViewModel);
        }
    }
}
