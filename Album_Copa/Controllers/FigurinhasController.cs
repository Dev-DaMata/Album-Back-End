using Album_Copa.IRepository;
using Album_Copa.Model;
using Album_Copa.Repository;
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
    public class FigurinhasController : Controller
    {
        #region Injeção de Dependências
        private readonly IConfiguration _configuration;

        private readonly ILogger<FigurinhasController> _logger;

        private readonly IFigurinhasRepository _figurinhasRepository;

        public FigurinhasController(IConfiguration config, ILogger<FigurinhasController> logger, IFigurinhasRepository figurinhasRepository)
        {
            _configuration = config;
            _logger = logger;
            _figurinhasRepository = figurinhasRepository;
        }

        #endregion

        #region figurinhas

        [HttpGet]
        [Route("getFigurinhas")]
        public async Task<ActionResult<List<Figurinhas>>> getFigurinhas()
        {
            try
            {
                var data = await _figurinhasRepository.GetFigurinhas();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetFigurinhas: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }

        }

        #endregion


    }
}
