using domus.Authentication;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#nullable disable

namespace domus.Models
{
    [DataContract]
    public partial class Participant
    {
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public int EventId { get; set; }
        [DataMember]
        public bool Accepted { get; set; }
        [DataMember]
        public bool Declined { get; set; }
        [DataMember]
        public string Explanation { get; set; }
        
        public ApplicationUser User { get; set; }

        public virtual Event Event { get; set; }
    }
}
