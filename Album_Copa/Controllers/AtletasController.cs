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
    public class AtletasController : Controller
    {
        #region Injeção de Dependências
        private readonly IConfiguration _configuration;

        private readonly ILogger<AtletasController> _logger;

        private readonly IAtletasRepository _atletasRepository;

        public AtletasController(IConfiguration config, ILogger<AtletasController> logger, IAtletasRepository atletasRepository)
        {
            _configuration = config;
            _logger = logger;
            _atletasRepository = atletasRepository;
        }

        #endregion

        #region ATLETAS 

        [HttpGet]
        [Route("getAtletas")]
        public async Task<ActionResult<List<Atletas>>> getAtletas()
        {
            try
            {
                var data = await _atletasRepository.GetAtletas();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAtletas: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }

        }

        [HttpGet]
        [Route("getAtleta/{id_atleta}")]
        public async Task<ActionResult<Atletas>> getAtleta(int id_atleta)
        {
            try
            {
                var data = await _atletasRepository.GetAtleta(id_atleta);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAtleta: Erro na requisição dos dados");
                return new StatusCodeResult(500);
            }

        }

        [HttpPost]
        [Route("createAtletas")]
        public async Task<ActionResult<bool>> CreateAtletas(Atletas model)
        {
            try
            {
                var data = await _atletasRepository.CreateAtletas(model);
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateAtletas: Erro na requisição dos dados");
                return false;
            }

        }
        #endregion

        [HttpDelete]
        [Route("deleteAtleta")]
        public async Task<ActionResult<bool>> deleteAtletas(int id_atleta)
        {
            try
            {
                var data = await _atletasRepository.DeleteAtletas(id_atleta);
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DeleteTime: Erro na requisição dos dados");
                return false;
            }
        }
        
        [HttpPut]
        [Route("updateAtleta")]
        public async Task<ActionResult<bool>> updateAtletas(Atletas model)
        {
            try
            {
                var data = await _atletasRepository.UpdateAtletas(model);
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpdateAtletas: Erro na requisição dos dados");
                return false;
            }
        }

    }
}
