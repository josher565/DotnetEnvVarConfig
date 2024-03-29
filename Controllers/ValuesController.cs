﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetEnvVarConfig.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace DotnetEnvVarConfig.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IConfiguration Config { get; set; }

        public ValuesController(IConfiguration config){
            Config = config;
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var env_vars = new List<string>();
            foreach(var myvar in Config.GetChildren()){
                env_vars.Add($"{myvar.Key} : {myvar.Value}");
            }
            return env_vars;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
