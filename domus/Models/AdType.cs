using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#nullable disable

namespace domus.Models
{
    [DataContract]
    public partial class AdType
    {
        public AdType()
        {
            Ads = new HashSet<Ad>();
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }
    }
}
