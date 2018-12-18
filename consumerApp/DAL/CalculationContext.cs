using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL
{
    public class CalculationContext : DbContext
    {
        public CalculationContext(DbContextOptions<CalculationContext> options) : base(options) {}
        public DbSet<CalculationOption> CalculationOptions { get; set; }
    }
}