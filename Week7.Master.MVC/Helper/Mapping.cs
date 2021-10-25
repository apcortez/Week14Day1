using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.MVC.Models;

namespace Week7.Master.MVC.Helper
{
    public static class Mapping
    {

        public static Corso toCorso(this CorsoViewModel corsoViewModel)
        {
            return new Corso
            {
                CorsoCodice = corsoViewModel.CorsoCodice,
                Nome = corsoViewModel.Nome,
                Descrizione = corsoViewModel.Descrizione,
                //Lezioni = null, Studenti = null
            };
        }

        public static CorsoViewModel toCorsoViewModel(this Corso corso)
        {
            return new CorsoViewModel
            {
                CorsoCodice = corso.CorsoCodice,
                Nome = corso.Nome,
                Descrizione = corso.Descrizione
                
            };
        }

        public static Docente toDocente(this DocenteViewModel docenteViewModel)
        {
            return new Docente
            {
                ID = docenteViewModel.ID,
                Nome = docenteViewModel.Nome,
                Cognome = docenteViewModel.Cognome,
                Email = docenteViewModel.Email,
                Telefono = docenteViewModel.Telefono

            };
        }

        public static DocenteViewModel ToDocenteViewModel(this Docente docente)
        {
            return new DocenteViewModel
            {
                ID = docente.ID,
                Nome = docente.Nome,
                Cognome = docente.Cognome,
                Email = docente.Email,
                Telefono = docente.Telefono
            };
        }

        public static Studente toStudente(this StudenteViewModel studenteViewModel)
        {
            return new Studente
            {

                ID = studenteViewModel.ID,
                Nome = studenteViewModel.Nome,
                Cognome = studenteViewModel.Cognome,
                Email = studenteViewModel.Email,
                DataNascita = studenteViewModel.DataNascita,
                TitoloStudio = studenteViewModel.TitoloStudio

            };
        }

        public static StudenteViewModel ToStudenteViewModel(this Studente studente)
        {
            return new StudenteViewModel
            {
                ID = studente.ID,
                Nome = studente.Nome,
                Cognome = studente.Cognome,
                Email = studente.Email,
                DataNascita = studente.DataNascita,
                TitoloStudio = studente.TitoloStudio
            };
        }
    }
}
