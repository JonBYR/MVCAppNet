using Microsoft.EntityFrameworkCore;
namespace MVCApp.Models
{
    public class MVCAppDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public MVCAppDbContext(DbContextOptions<MVCAppDbContext> options) : base(options)
        {
        }
    }
}
