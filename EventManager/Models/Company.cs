namespace EventManager.Models
{
    public class Company
    {
        public int Id { get; set; }
        public Participant Participant { get; set; }
        public int ParticipantId { get; set; }

        public string LegalName { get; set; }
        public int RegistryNumber { get; set; }
        public string Info { get; set; }
    }
}