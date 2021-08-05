using Microsoft.EntityFrameworkCore;
using UserApi.DAL.Entities;

namespace UserApi.DAL.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person_ConnectedPerson>()
                .HasOne(p => p.Person)
                .WithMany(cp => cp.ConnectedPeople)
                .HasForeignKey(pid => pid.PersonId);
            modelBuilder.Entity<Person_ConnectedPerson>()
                .HasOne(p => p.ConnectedPerson)
                .WithMany(cp => cp.ConnectedPeople)
                .HasForeignKey(cpid => cpid.ConnectedPersonId);
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Person_ConnectedPerson> Person_ConnectedPErson { get; set; }


    }
}
