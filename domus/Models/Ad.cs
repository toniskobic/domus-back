using domus.Authentication;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#nullable disable

namespace domus.Models
{
    [DataContract]
    public partial class Ad
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int AdTypeId { get; set; }
        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public virtual ApplicationUser User { get; set; }
        [DataMember]
        public virtual AdType AdType { get; set; }
    }
}
