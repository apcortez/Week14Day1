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
    public class StudentiController : Controller
    {
        private readonly IBusinessLayer BL;
        public StudentiController(IBusinessLayer BL)
        {
            this.BL = BL;
        }

        public IActionResult Index()
        {
            var studenti = BL.GetAllStudenti();
            List<StudenteViewModel> studentiViewModel = new List<StudenteViewModel>();
            foreach (var s in studenti)
            {
                studentiViewModel.Add(s.ToStudenteViewModel());
            }

            return View(studentiViewModel);
        }

        [HttpGet("Studenti/Details/{ID}")]
        public IActionResult Details(int ID)
        {
            var studente = BL.GetAllStudenti().Where(s => s.ID == ID).FirstOrDefault();
            var studenteViewModel = studente.ToStudenteViewModel();

            return View(studenteViewModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var studente = BL.GetAllStudenti().Where(d => d.ID == id).FirstOrDefault();
            var studenteViewModel = studente.ToStudenteViewModel();

            return View(studenteViewModel);
        }

        [HttpPost]
        public IActionResult Update(StudenteViewModel studenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var studente = studenteViewModel.toStudente();
                BL.ModificaStudente(studente.ID, studente.Email);
                return RedirectToAction(nameof(Index));
            }
            return View(studenteViewModel);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var studente = BL.GetAllStudenti().Where(d => d.ID == id).FirstOrDefault();
            var studenteViewModel = studente.ToStudenteViewModel();
            return View(studenteViewModel);
        }

        [HttpPost]
        public IActionResult Delete(DocenteViewModel studenteViewModel)
        {
            if (ModelState.IsValid)
            {

                var studente = studenteViewModel.toDocente();
                BL.EliminaStudente(studente.ID);
                return RedirectToAction(nameof(Index));

            }
            return View(studenteViewModel);
        }
    }
}
