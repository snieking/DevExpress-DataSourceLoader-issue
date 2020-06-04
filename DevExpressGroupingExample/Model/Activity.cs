using System.Collections.Generic;

namespace DevExpressGroupingExample.Model
{
    public class Activity
    {
        public int Sk { get; set; }
        public virtual string Name { get; set; }
        public ICollection<ActivityParticipant> ActivityParticipants { get; set; }
    }
}