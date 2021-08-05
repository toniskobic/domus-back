using System;
using System.Collections.Generic;

#nullable disable

namespace domus.Models
{
    public partial class Grad
    {
        public Grad()
        {
            Doms = new HashSet<Dom>();
        }

        public int GradId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Dom> Doms { get; set; }
    }
}
