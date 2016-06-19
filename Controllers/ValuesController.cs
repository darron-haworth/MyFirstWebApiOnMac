using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.AspNetCore.Builder;


namespace MyFirstWebApiOnMac.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {

            var pgUser = Environment.GetEnvironmentVariable("DbUser");
            var pgPw = Environment.GetEnvironmentVariable("DbPw");
            var connString = String.Format("Host=127.0.0.1;Username={0};Password={1};Database=DHSandbox", pgUser, pgPw);

            var retVals = new List<String>();

                using (var conn = new NpgsqlConnection(connString))   
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;

                        // Insert some data
                        cmd.CommandText = "SELECT * FROM public.\"Person\"";

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            { 
                                var fullName = string.Format("{0} {1}", reader.GetString(1), reader.GetString(2));
                                retVals.Add(fullName);
                            }
                        }
                    }
                }
            return retVals.ToArray();
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
