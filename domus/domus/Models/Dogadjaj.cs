using System;
using System.Collections.Generic;

#nullable disable

namespace domus.Models
{
    public partial class Dogadjaj
    {
        public Dogadjaj()
        {
            Sudioniks = new HashSet<Sudionik>();
        }

        public int DogadjajId { get; set; }
        public string Naziv { get; set; }
        public DateTime VrijemePocetka { get; set; }
        public DateTime VrijemeZavrsetka { get; set; }
        public int BrojSudionika { get; set; }
        public string Opis { get; set; }
        public int TipDogadjajaId { get; set; }
        public int KorisnikId { get; set; }
        public int DomId { get; set; }

        public virtual Dom Dom { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual TipDogadjaja TipDogadjaja { get; set; }
        public virtual ICollection<Sudionik> Sudioniks { get; set; }
    }
}
