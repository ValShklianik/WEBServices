using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;


namespace DAL
{
    public class CalculationContextFactory : IDesignTimeDbContextFactory<CalculationContext>
    {
        public CalculationContextFactory()
        {
        }


        public CalculationContext CreateDbContext(string[] args = null)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<CalculationContext>();
            var connectionString = configuration["ConnectionString"];
            builder.UseNpgsql(connectionString);

            return new CalculationContext(builder.Options);
        }
    }
}