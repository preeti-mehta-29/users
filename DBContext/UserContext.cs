using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.DBContext
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public UserContext() { }
        public DbSet<User> Users {  get; set; } 

    }
}
