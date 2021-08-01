using Microsoft.EntityFrameworkCore;

namespace UserApi.DAL.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
       
    }
}
