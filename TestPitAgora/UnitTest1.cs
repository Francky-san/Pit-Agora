using PitAgora;
using PitAgora.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestPitAgora
{
    public class UnitTest1
    {
        [Fact]
        public void Creer_Professeur_Verification()
        {
            using (DalParents dal = new DalParents())
            {
                // Nous supprimons et cr�ons la db avant le test
                dal.DeleteCreateDatabase();
                // Nous cr�ons un lieu de vacances
                dal.CreerProfesseur("TANGUY", "Franck","franck@yahoo.fr","Hina","125 rue de normandie","EPS");

                // Nous v�rifions que le lieu a bien �t� cr��
                List<Professeur> professeurs = dal.ObtientTousLesProfesseurs();
                Assert.NotNull(professeurs);
                Assert.Single(professeurs);
                Assert.Equal("EPS", professeurs[0].Matiere1);
            }

        }

       /*[Fact]
        public void Creer_Eleve_Verification()
        {
            using Dal dal = new Dal();
            // Nous supprimons et cr�ons la db avant le test
            dal.DeleteCreateDatabase();
            // Nous cr�ons un lieu de vacances
            dal.CreerEleve("BARREAU", "Joseph", "Joseph@hotmail.com", "Lulu", "15 rue de Bearn", 400);

            // Nous v�rifions que l'�l�ve a bien �t� cr��
            List<Eleve> eleves = dal.ObtientTousLesELeves();
            Assert.NotNull(eleves);
            Assert.Single(eleves);
            Assert.Equal(400, eleves[0].CreditCours);
        }*/
    }
}
