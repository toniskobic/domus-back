using System;
using System.Collections.Generic;

#nullable disable

namespace domus.Models
{
    public partial class Oglas
    {
        public int OglasId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int TipOglasaId { get; set; }
        public int KorisnikId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual TipOglasa TipOglasa { get; set; }
    }
}
