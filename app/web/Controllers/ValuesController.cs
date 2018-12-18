using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scheduler;
using DAL;

namespace web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<long>> Get([FromQuery] long value)
        {
            var repository = new CalculationRepository();
            return repository.GetOption(value).Result;
        }

        // POST api/values
        [HttpPost]
        public long Post([FromBody] long value)
        {
            var scheduler = new FibonacciSheduler();
            return scheduler.SendMessage(value);
        }
    }
}
