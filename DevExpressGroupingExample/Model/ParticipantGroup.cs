namespace DevExpressGroupingExample.Model
{
    public class ParticipantGroup
    {
        public virtual int ParticipantSk { get; set; }
        public virtual int GroupSk { get; set; }
        public virtual string GroupName { get; set; }
        public virtual string GroupCategory { get; set; }
        public virtual Participant Participant { get; set; }
    }
}