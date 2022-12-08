using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace PitAgora.Models
{
    public class Niveau
    {
        public static readonly List<string> lesNiveaux = new List<string>() { "scq", "ts", "pt" };

        public static readonly Dictionary<string, string> dictNiveaux = new Dictionary<string, string>()
        {
            {"6","scq"},
            {"5","scq"},
            {"4","scq"},
            {"3","ts"},
            {"2","ts"},
            {"1G","pt"},
            {"1T","pt"},
            {"TG","pt"},
            {"TT","pt"},
        };

        public int Id { get; set; }
        public string Intitule { get; set; }

      
    }
}
