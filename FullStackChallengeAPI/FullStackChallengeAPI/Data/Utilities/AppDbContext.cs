using FullStackChallengeAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace FullStackChallengeAPI.Data.Utilities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

   
}