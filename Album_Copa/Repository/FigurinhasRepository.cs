using Album_Copa.Controllers;
using Album_Copa.IRepository;
using Album_Copa.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;


namespace Album_Copa.Repository
{
    public class FigurinhasRepository : IFigurinhasRepository
    {
        #region Injeção de Dependências

        private readonly IConfiguration _config;
    
        public FigurinhasRepository(IConfiguration config)
        {
            _config = config;
        }

        #endregion


        #region Times

        public async Task<List<Figurinhas>> GetFigurinhas()
        {
            var response = new List<Figurinhas>();

            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));


            string query = @"SELECT * FROM Figurinhas_copa(nolock)";
            response = (List<Figurinhas>)await connection.QueryAsync<Figurinhas>(query);

            return response;
        }

        public async Task<Figurinhas> GetFigurinha(int id_figurinha)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));


            var param = new DynamicParameters();
            param.Add("id_figurinha", id_figurinha, direction: ParameterDirection.Input);

            var query = @"SELECT * FROM Figurinhas_copa(nolock) WHERE id_figurinha = @id_figurinha";

            var response = await connection.QueryFirstAsync<Figurinhas>(query, param);

            return response;

        }

        #endregion
    }
}
