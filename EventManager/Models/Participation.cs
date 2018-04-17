using EventManager.enums;

namespace EventManager.Models
{
    public class Participation
    {
        public int Id { get; set; }
        public Participant Participant { get; set; }
        public int ParticipantId { get; set; }
        public Event Event { get; set; }
        public int EventId { get; set; }

        public int GuestCount { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}