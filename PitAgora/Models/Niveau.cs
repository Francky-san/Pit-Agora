using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace PitAgora.Models
{
    public class Niveau
    {
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
            
        public int Id { get; set; }
        public string Intitule { get; set; }

      
    }
}
