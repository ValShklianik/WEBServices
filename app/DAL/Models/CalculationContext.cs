using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    public class CalculationContext : DbContext
    {
        public CalculationContext(DbContextOptions<CalculationContext> options) : base(options) {}
        public DbSet<CalculationOption> CalculationOptions { get; set; }     
    }
}