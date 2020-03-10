using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Cytel.Top.Api.Messages;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cytel.Top.Api.Services
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILoggerManager _logger;
        public ValuesController(ILoggerManager logger)
        {
            _logger = logger;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInfo("Fetching all the Students from the storage");

                var studyList = new List<StudyDetail>
                    {
                        new StudyDetail{ name = "Study1", phase="Phase1" },
                        new StudyDetail{ name = "Study2", phase="Phase2" },
                        new StudyDetail{ name = "Study3", phase="Phase3" }
                    };


                _logger.LogInfo($"Returning {studyList.Count} students.");
                int c = 10, d = 0;
                int a = c / d;

                return Ok(studyList);
            }
            catch (Exception ex)
            {
               string errorCode = $"CY-{((int)MessageCodes.Message.DivideByZeroException).ToString()}";
                _logger.LogError($"Something went wrong: {errorCode} {ex}");
                throw ex;
            }
        }

        // GET: api/<controller>
        [HttpGet, MapToApiVersion("1.1")]
        public IEnumerable<string> Get_Values()
        {
            return new string[] { "value1", "value2", "value3", "value4" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
