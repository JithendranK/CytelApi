using Contracts;
using Cytel.Top.Api.Interfaces;
using Cytel.Top.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace Cytel.Top.Api.Controllers
{
    /// <summary>
    /// API Controller class for Performming GET /POST actions
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}")]
    //[ApiVersion("1.0", Deprecated = true)]
   // [ApiVersionNeutral]
    [ApiController]
    public class StudyController : ControllerBase
    {
        /// <summary>
        /// Study Repository Object
        /// </summary>
        private readonly IStudyService _studyService;
        private readonly ILoggerManager _logger;
        /// <summary>
        /// Injecting the configuration object to the constructor
        /// </summary>
        /// <param name="studyService"></param>
        /// /// <param name="logger"></param>
        public StudyController(IStudyService studyService, ILoggerManager logger)
        {
            _studyService = studyService;
            _logger = logger;
        }

       /// <summary>
       /// GET API endpoint , it returns all study details in JSON format
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        [Route("studies")]
        public IEnumerable<Study> Get()
        {
            //string testexception = "Error";
            //int i = int.Parse(testexception);
            _logger.LogInfo("Getting All Study Related Objects From Study Servce.");
            //_logger.LogDebug("Here is debug message from the controller.");
            //_logger.LogWarn("Here is warn message from the controller.");
            //_logger.LogError("Here is error message from the controller.");
            IEnumerable<Study> listAll = _studyService.FindAll();
            _logger.LogInfo($"Successfully returned values");
            //throw new Exception("Exception While fetching the records");

            return listAll;
        }

        /// <summary>
        /// POST API endpoint , studies can be created using this endpoint, input parameter is study object 
        /// </summary>
        /// <param name="_input"></param>
        [HttpPost]
        [Route("studies")]
        public void Post(Study _input)
        {
            _studyService.Add(_input);
        }
    }
}