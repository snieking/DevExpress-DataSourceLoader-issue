using System.Collections.Generic;

namespace DevExpressGroupingExample.Model
{
    public class Participant
    {
        public virtual int Sk { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public ICollection<ActivityParticipant> ActivityParticipants { get; set; }
        public ICollection<ParticipantGroup> ParticipantGroups { get; set; }
    }
}