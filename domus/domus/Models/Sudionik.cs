using System;
using System.Collections.Generic;

#nullable disable

namespace domus.Models
{
    public partial class Sudionik
    {
        public int DogadjajId { get; set; }
        public int KorisnikId { get; set; }
        public bool Potvrdjen { get; set; }
        public bool Odbijen { get; set; }
        public string Obrazlozenje { get; set; }

        public virtual Dogadjaj Dogadjaj { get; set; }
        public virtual Korisnik Korisnik { get; set; }
    }
}
