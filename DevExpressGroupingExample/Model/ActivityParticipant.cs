namespace DevExpressGroupingExample.Model
{
    public class ActivityParticipant
    {
        public int ActivitySk { get; set; }
        public int ParticipantSk { get; set; }
        public virtual string ResultStatus { get; set; }
        public Activity Activity { get; set; }
        public Participant Participant { get; set; }
    }
}