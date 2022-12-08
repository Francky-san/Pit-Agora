using System;

namespace PitAgora.Models
{
    public class DalNiveauxProf : IDisposable
    {
        private BddContext _bddContext;
        public DalNiveauxProf()
        {
            _bddContext = new BddContext();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }

    //public int CreerNiveauxProf(int profId, int niveauId)
    //{
    //    DalGen dal = new DalGen();
    //    int personneId = dal.CreerPersonne(nom, prenom);
    //    int utilisateurId = dal.CreerUtilisateur(personneId, mail, motDePasse, adresse);
    //    Eleve eleve = new Eleve() { UtilisateurId = utilisateurId, CreditCours = creditCours };
    //    _bddContext.Eleves.Add(eleve);
    //    _bddContext.SaveChanges();
    //    return eleve.Id;
    //}

}
