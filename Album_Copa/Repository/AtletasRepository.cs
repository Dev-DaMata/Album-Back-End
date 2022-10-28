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
    public class AtletasRepository : IAtletasRepository
    {
        #region Injeção de Dependências

        private readonly IConfiguration _config;
    
        public AtletasRepository(IConfiguration config)
        {
            _config = config;
        }

        #endregion


        #region Atletas 

        public async Task<List<Atletas>> GetAtletas()
        {
            var response = new List<Atletas>();

            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));


            string query = @"SELECT * FROM Atletas_copa(nolock)";
            response = (List<Atletas>)await connection.QueryAsync<Atletas>(query);

            return response;
        }

        #endregion
    }
}
