using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace PitAgora.Models
{
    public class Niveau
    {
        public static readonly List<string> lesNiveaux = new List<string>() { "scq", "ts", "pt" };
        public int Id { get; set; }
        public string Intitule { get; set; }

      
    }
}
