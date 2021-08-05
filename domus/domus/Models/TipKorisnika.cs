using System;
using System.Collections.Generic;

#nullable disable

namespace domus.Models
{
    public partial class TipKorisnika
    {
        public TipKorisnika()
        {
            Korisniks = new HashSet<Korisnik>();
        }

        public int TipKorisnikaId { get; set; }
        public string Naziv { get; set; }
        public int RazinaAutorizacije { get; set; }

        public virtual ICollection<Korisnik> Korisniks { get; set; }
    }
}
