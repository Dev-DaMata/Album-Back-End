using Album_Copa.IRepository;
using Album_Copa.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace Album_Copa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimesController : Controller
    {
        #region Injeção de Dependências
        private readonly IConfiguration _configuration;

        private readonly ILogger<TimesController> _logger;

        private readonly ITimesRepository _timesRepository;

        public TimesController(IConfiguration config, ILogger<TimesController> logger, ITimesRepository timesRepository)
        {
             _configuration = config;
             _logger = logger;
             _timesRepository = timesRepository;
        }  

            #endregion

        #region Times
        
        [HttpGet]
        [Route("getTimes")]
        public async Task<ActionResult<List<Times>>> getTimes()
        {
            try
            {
                var data = await _timesRepository.GetTimes();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetCor: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }

        }

        [HttpGet]
        [Route("getTime/{id_time}")]
        public async Task<ActionResult<Times>> getTime(int id_time)
        {
            try
            {
                var data = await _timesRepository.GetTime(id_time);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetTime: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }

        }

        #endregion
    }


}
