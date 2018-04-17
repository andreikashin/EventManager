using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public class Person
    {
        public int Id { get; set; }
        public Participant Participant { get; set; }
        public int ParticipantId { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int PersonalCode { get; set; }

        [StringLength(1500)]
        public string Info { get; set; }
    }
}