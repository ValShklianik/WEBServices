using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace DAL
{
    public class DALContextFactory : IDesignTimeDbContextFactory<CalculationContext>
    {
        public DALContextFactory()
        {
        }


        public CalculationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CalculationContext>();
            builder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres");

            return new CalculationContext(builder.Options);
        }
    }
}