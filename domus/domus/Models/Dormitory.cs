using domus.Authentication;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#nullable disable

namespace domus.Models
{
    [DataContract]
    public partial class Dormitory
    {
        public Dormitory()
        {
            Events = new HashSet<Event>();
            Users = new HashSet<ApplicationUser>();
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int CityId { get; set; }
        [DataMember]
        public virtual City City { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
