using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace PitAgora.Models
{
    public class DalCreneaux : IDisposable
    {
        private BddContext _bddContext;
        public DalCreneaux()
        {
            _bddContext = new BddContext();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }

        public string GetMatiere(int IdCreneau)
        {
            var query = from c in _bddContext.Creneaux
                        join p in _bddContext.Professeurs on c.ProfesseurId equals p.Id
                        join mp in _bddContext.MatiereProf on p.Id equals mp.ProfesseurId
                        join m in _bddContext.Matieres on mp.MatiereId equals m.Id
                        where c.Id == IdCreneau
                        select m;
            return query.ToString();
        }

        public int CreerCreneau(DateTime debut, int professeurId)
        {
            Creneau creneau = new Creneau() { Debut = debut, ProfesseurId = professeurId };
            _bddContext.Creneaux.Add(creneau);
            _bddContext.SaveChanges();
            return creneau.Id;
        }
        //Creer résa
        //public int CreerResa(List<Creneau> creneaux)
        //{
        //    string prof =
        //        if (creneaux.Count % 2 == 0)
        //    {
        //        int prix = (creneaux.Count);
        //    }
        //    Reservation newResa = new Reservation()
        //    {

        //        DureeMinutes = creneaux.Count() * 30,
        //        Evaluation = null,
        //        PrenomNomProf = (creneaux[0].Professeur.Utilisateur.Personne.Prenom) + " " + (creneaux[0].Professeur.Utilisateur.Personne.Nom),
        //        Prix = creneaux[0].,
        //        Horaire = creneaux[0].Debut,


        //    }
        //}

        public Creneau GetCreneau(int id)
        {
            return _bddContext.Creneaux.Find(id);
        }

        public List<Creneau> RequeteDistanciel(MatiereEnum matiere, string niveau, DateTime debut, DateTime fin)
        {
            // une requête par le bddContext est-elle possible quand elle implique une relation 'plusieurs à plusieurs' ?
            var query = from c in _bddContext.Creneaux
                        join p in _bddContext.Professeurs on c.ProfesseurId equals p.Id
                        join np in _bddContext.NiveauxProfs on p.Id equals np.ProfesseurId
                        join n in _bddContext.Niveaux on np.NiveauId equals n.Id
                        //where c.Id.CompareTo(8) >= 0
                        where n.Intitule.Equals(niveau) && c.Debut.CompareTo(debut) >= 0 && c.Debut.CompareTo(fin) < 0 //&& (p.Matiere1.Equals(matiere) || p.Matiere2.Equals(matiere))
                        orderby p.Id, c.Debut
                        select c;
            //select new { c.ProfesseurId, c.Debut, c.Id };
            //var query = _bddContext.Creneaux.Where(c => c.Id >= 8);
            return query.Take(50).ToList();
        }

        public List<Creneau> RequeteDistanciel2(MatiereEnum matiere, string niveau, DateTime debut, DateTime fin)
        {
            // une requête par le bddContext est-elle possible quand elle implique une relation 'plusieurs à plusieurs' ?
            var query = _bddContext.Creneaux.FromSqlRaw("select c.*, n.intitule, p.matiere1, p.matiere2  from creneaux as c" +
                " inner join professeurs as p on p.id=c.professeurId" +
                " inner join niveauxprofs as np on np.ProfesseurId=p.id" +
                " inner join niveaux as n on n.id=np.niveauid" +
            " where n.intitule='" + niveau + "' and c.debut between '" + FormateDate(debut) + "' and '" + FormateDate(fin) + "'" +
            " and (p.matiere1 = '" + matiere + "' or p.matiere2 = '" + matiere + "')" +
                " order by c.professeurid desc, c.debut"
                );
            return query.Take(1000).ToList();
        }

        // Mise au format YYYY-MM-DD HH:MM:SS d'une DateTime
        public string FormateDate(DateTime d)
        {
            return d.Year + "-" + d.Month + "-" + d.Day + " " + d.Hour + ":" + d.Minute + ":" + d.Second;
        }
    }
}
