using System;
using System.Collections.Generic;

#nullable disable

namespace domus.Models
{
    public partial class Dom
    {
        public Dom()
        {
            Dogadjajs = new HashSet<Dogadjaj>();
            Korisniks = new HashSet<Korisnik>();
        }

        public int DomId { get; set; }
        public string Naziv { get; set; }
        public int GradId { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual ICollection<Dogadjaj> Dogadjajs { get; set; }
        public virtual ICollection<Korisnik> Korisniks { get; set; }
    }
}
