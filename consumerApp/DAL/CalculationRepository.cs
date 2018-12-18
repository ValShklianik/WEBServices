using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL
{
    public class CalculationRepository : ICalculationRepository
    {
        private CalculationContextFactory contextFactory = new CalculationContextFactory();

        public long AddOption(long value)
        {
            long optionId;
            using (var context = contextFactory.CreateDbContext())
            {
                var option = context.CalculationOptions.Add(
                    new CalculationOption()
                    {
                        InputData = value
                    }
                );
                context.SaveChanges();
                optionId = option.Entity.Id;
            }
            return optionId;
        }

        public CalculationOption GetOption(long optionId)
        {
            CalculationOption option = null;
            using (var context = contextFactory.CreateDbContext())
            {
                option = context.CalculationOptions.Find(optionId);
            }
            return option;
        }

        public void SaveResult(long id, List<long> numbers)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                var option = context.CalculationOptions.Find(id);
                option.Result = numbers;
                context.SaveChanges();
            } 
        }
    }
}
