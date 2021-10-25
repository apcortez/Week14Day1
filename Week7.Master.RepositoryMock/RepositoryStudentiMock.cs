using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.RepositoryMock
{
    public class RepositoryStudentiMock : IRepositoryStudenti
    {

        public static List<Studente> Studenti = new List<Studente>() 
        { 
        new Studente{ ID = 1, Nome= "Pippo", Cognome = "Neri", TitoloStudio = "Ingegneria", DataNascita = new DateTime(2000,12,12), Email = "pippo@email.it"},
        new Studente{ ID = 2, Nome= "Pluto", Cognome = "Verdi", TitoloStudio = "Informatica", DataNascita = new DateTime(1999,10,12), Email = "pluto@email.it"},
        new Studente{ ID = 3, Nome= "Minnie", Cognome = "Rosa", TitoloStudio = "Letteratura", DataNascita = new DateTime(2003,07,31), Email = "minnie@email.it"}
        };



        public Studente Add(Studente item)
        {
            if (Studenti.Count == 0)
            {
                item.ID = 1;
            }
            else
            {
                item.ID = Studenti.Max(s => s.ID) + 1;
            }

            var corso = RepositoryCorsiMock.Corsi.FirstOrDefault(c => c.CorsoCodice == item.CorsoCodice);
            item.Corso = corso;
            corso.Studenti.Add(item);

            Studenti.Add(item);
            return item;
        }

        public bool Delete(Studente item)
        {
            Studenti.Remove(item);
            return true;
        }

        public List<Studente> GetAll()
        {
            return Studenti;
        }

        public Studente GetById(int id)
        {
            return Studenti.FirstOrDefault(s => s.ID == id);
        }

        public Studente Update(Studente item)
        {
            var old = GetById(item.ID);           
            old.Email = item.Email;
            return item;
        }
    }
}
