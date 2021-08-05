using System;
using System.Collections.Generic;

#nullable disable

namespace domus.Models
{
    public partial class TipOglasa
    {
        public TipOglasa()
        {
            Oglas = new HashSet<Oglas>();
        }

        public int TipOglasaId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Oglas> Oglas { get; set; }
    }
}
