using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#nullable disable

namespace domus.Models
{
    [DataContract]
    public partial class City
    {
        public City()
        {
            Dormitories = new HashSet<Dormitory>();
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        public virtual ICollection<Dormitory> Dormitories { get; set; }
    }
}
