using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace DAL
{
    public class CalculationContextFactory : IDesignTimeDbContextFactory<CalculationContext>
    {
        public CalculationContextFactory()
        {
        }


        public CalculationContext CreateDbContext(string[] args = null)
        {
            var builder = new DbContextOptionsBuilder<CalculationContext>();
            builder.UseNpgsql("Host=192.168.0.105;Port=5432;Database=postgres;Username=postgres;Password=postgres");

            return new CalculationContext(builder.Options);
        }
    }
}