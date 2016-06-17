using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebApiOnMac.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Random rnd = new Random();
            int numValues = rnd.Next(5, 50); // creates a number between 1 and 12
            var retVals = new string[numValues];
            for(int i=0; i< numValues; i++){
                retVals[i] = "value" + i.ToString();
            }
            return retVals;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var val = "value" + id.ToString();
            return val;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
