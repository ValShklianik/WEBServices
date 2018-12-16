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
            throw new NotImplementedException();
        }

        public void SaveResult(long id, IEnumerable<long> numbers)
        {
            throw new NotImplementedException();
        }
    }
}
