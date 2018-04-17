using System.Data.Entity;

namespace EventManager.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Person> People { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}