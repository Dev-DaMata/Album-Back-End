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
    public class TimesRepository : ITimesRepository
    {
        #region Injeção de Dependências

        private readonly IConfiguration _config;

        public TimesRepository(IConfiguration config)
        {
            _config = config;
        }

        #endregion


        #region Times
        public async Task<List<Times>> GetTimes()
        {
            var response = new List<Times>();

            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));


            string query = @"SELECT * FROM Times(nolock)";
            response = (List<Times>)await connection.QueryAsync<Times>(query);

            return response;
        }

        public async Task<Times> GetTime(int id_time)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));


            var param = new DynamicParameters();
            param.Add("id_time", id_time, direction: ParameterDirection.Input);

            var query = @"SELECT * FROM Times(nolock) WHERE id_time = @id_time";

            var response = await connection.QueryFirstAsync<Times>(query, param);

            return response;

        }

        #endregion
    }
}
