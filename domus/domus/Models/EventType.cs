using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#nullable disable

namespace domus.Models
{
    [DataContract]
    public partial class EventType
    {
        public EventType()
        {
            Events = new HashSet<Event>();
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
