using Microsoft.EntityFrameworkCore;

namespace UsersWPI.Model
{
    public class UserDbcontext:DbContext
    {
        public UserDbcontext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Users> users { get; set; }
    }
}
