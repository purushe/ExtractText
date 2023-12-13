using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TextReader.Data.Database
{
  public class DatabaseContext : IdentityDbContext<ApplicationUser>
  {
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
  }
}
