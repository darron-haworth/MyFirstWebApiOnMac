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
using MyFirstWebApiOnMac.Models;

namespace MyFirstWebApiOnMac.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        // GET api/persons
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var retPersons = new List<Person>();
            //We don't want to store DB credentials in source code, pull them from the following Environment Variables
            var pgUser = Environment.GetEnvironmentVariable("DbUser");
            var pgPw = Environment.GetEnvironmentVariable("DbPw");
            var connString = String.Format("Host=127.0.0.1;Username={0};Password={1};Database=darronh", pgUser, pgPw);

            

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
                                var nextPerson = new Person();
                                nextPerson.id = reader.GetInt32(0);
                                nextPerson.FirstName = reader.GetString(1);
                                nextPerson.LastName = reader.GetString(2);
                                nextPerson.City = reader.GetString(3);

                                retPersons.Add(nextPerson);
                            }
                        }
                    }
                }
            return retPersons.ToArray();
        }

        // GET api/persons/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            //We don't want to store DB credentials in source code, pull them from the following Environment Variables
            var pgUser = Environment.GetEnvironmentVariable("DbUser");
            var pgPw = Environment.GetEnvironmentVariable("DbPw");
            var connString = String.Format("Host=127.0.0.1;Username={0};Password={1};Database=darronh", pgUser, pgPw);

            var returnPerson = new Person();

                using (var conn = new NpgsqlConnection(connString))   
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;

                        // Insert some data
                        cmd.CommandText = String.Format("SELECT * FROM public.\"Person\" WHERE id = {0}", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            { 
                                returnPerson.id = reader.GetInt32(0);
                                returnPerson.FirstName = reader.GetString(1);
                                returnPerson.LastName = reader.GetString(2);
                                returnPerson.City = reader.GetString(3);
                            }
                        }
                    }
                }

            return returnPerson;
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
