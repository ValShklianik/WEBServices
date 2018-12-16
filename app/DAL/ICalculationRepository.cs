using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL
{
    public interface ICalculationRepository
    {
        long AddOption(long value);
        CalculationOption GetOption(long optionId);
        void SaveResult(long id, IEnumerable<long> numbers);
    }
}
