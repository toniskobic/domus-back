using System;
using System.Collections.Generic;

#nullable disable

namespace domus.Models
{
    public partial class TipDogadjaja
    {
        public TipDogadjaja()
        {
            Dogadjajs = new HashSet<Dogadjaj>();
        }

        public int TipDogadjajaId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Dogadjaj> Dogadjajs { get; set; }
    }
}
