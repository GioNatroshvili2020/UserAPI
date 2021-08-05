using Microsoft.EntityFrameworkCore;
using UserApi.DAL.Entities;

namespace UserApi.DAL.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
        public DbSet<ConnectedPerson> ConnectedPeople { get; set; }
        public DbSet<City> City { get; set; }


    }
}
