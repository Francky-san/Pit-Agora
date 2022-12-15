using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace PitAgora.Models
{
    public class Niveau
    {
          
        public int Id { get; set; }
        public string Intitule { get; set; }


        public static readonly List<string> lesNiveaux = new List<string>() { "scq", "ts", "pt" };


        public static readonly Dictionary<NiveauEnum, string> dictNiveaux = new Dictionary<NiveauEnum, string>()
        {
            {NiveauEnum.sixieme,"scq"},
            {NiveauEnum.cinquieme,"scq"},
            {NiveauEnum.quatrieme,"scq"},
            {NiveauEnum.troisieme,"ts"},
            {NiveauEnum.seconde,"ts"},
            {NiveauEnum.premiereGenerale,"pt"},
            {NiveauEnum.premiereTechno,"pt"},
            {NiveauEnum.terminaleGenerale,"pt"},
            {NiveauEnum.terminaleTechno,"pt"}
            ,
        };
    }
    public enum NiveauEnum
    {
        [Display(Name = "6ème")]
        sixieme,
        [Display(Name = "5ème")]
        cinquieme,
        [Display(Name = "4ème")]
        quatrieme,
        [Display(Name = "3ème")]
        troisieme,
        [Display(Name = "2nde")]
        seconde,
        [Display(Name = "1ère Générale")]
        premiereGenerale,
        [Display(Name = "1ère Techno")]
        premiereTechno,
        [Display(Name = "Terminale Générale")]
        terminaleGenerale,
        [Display(Name = "Terminale Techno")]
        terminaleTechno

    }
}
