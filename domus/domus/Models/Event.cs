using domus.Authentication;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#nullable disable

namespace domus.Models
{
    [DataContract]
    public partial class Event
    {
        public Event()
        {
            Participants = new HashSet<Participant>();
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime DateFrom { get; set; }
        [DataMember]
        public DateTime DateTo { get; set; }
        [DataMember]
        public int Limit { get; set; }
        [DataMember]
        public bool Canceled { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int EventTypeId { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public int DormitoryId { get; set; }

        public virtual Dormitory Dormitory { get; set; }
        [DataMember]
        public virtual ApplicationUser User { get; set; }
        [DataMember]
        public virtual EventType EventType { get; set; }
        [DataMember]
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
