using System.Collections.Generic;

namespace DAL.Models
{
    public class CalculationOption
    {
        public long Id {get; set;}
        public long InputData {get; set;}
        public List<long> Result {get; set;}
    }
}