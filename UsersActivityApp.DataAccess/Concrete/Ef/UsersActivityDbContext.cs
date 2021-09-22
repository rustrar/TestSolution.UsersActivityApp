using Microsoft.EntityFrameworkCore;
using UsersActivityApp.Core.Entities.Concrete;

namespace UsersActivityApp.DataAccess.Concrete.Ef
{
  public class UsersActivityDbContext : DbContext
  {
    public UsersActivityDbContext(DbContextOptions<UsersActivityDbContext> options) : base(options)
    {
    }

    public DbSet<UserActivity> UserActivities { get; set; }
  }
}
