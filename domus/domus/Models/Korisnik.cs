using System;
using System.Collections.Generic;

#nullable disable

namespace domus.Models
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Dogadjajs = new HashSet<Dogadjaj>();
            Oglas = new HashSet<Oglas>();
            Sudioniks = new HashSet<Sudionik>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string EPosta { get; set; }
        public string LozinkaSha256 { get; set; }
        public string Salt { get; set; }
        public bool Zakljucan { get; set; }
        public int TipKorisnikaId { get; set; }
        public int DomId { get; set; }

        public virtual Dom Dom { get; set; }
        public virtual TipKorisnika TipKorisnika { get; set; }
        public virtual ICollection<Dogadjaj> Dogadjajs { get; set; }
        public virtual ICollection<Oglas> Oglas { get; set; }
        public virtual ICollection<Sudionik> Sudioniks { get; set; }
    }
}
