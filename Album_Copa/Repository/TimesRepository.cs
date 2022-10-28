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


            string query = @"SELECT * FROM Times_copa(nolock)";
            response = (List<Times>)await connection.QueryAsync<Times>(query);

            return response;
        }

        public async Task<Times> GetTime(int id_time)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));


            var param = new DynamicParameters();
            param.Add("id_time", id_time, direction: ParameterDirection.Input);

            var query = @"SELECT * FROM Times_copa(nolock) WHERE id_time = @id_time";

            var response = await connection.QueryFirstAsync<Times>(query, param);

            return response;

        }

        public async Task<bool> CreateTimes(Times model)
        {

            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            var param = new DynamicParameters();

            param.Add("id_time", model.id_time, direction: ParameterDirection.Input);
            param.Add("foto_brasao", model.foto_brasao, direction: ParameterDirection.Input);
            param.Add("nome_time", model.nome_time, direction: ParameterDirection.Input);

            var Id = "(SELECT isnull(max(id_time),0)+1 AS id_time FROM Times_copa(nolock))";

            var query = $@"INSERT INTO Times_copa (id_time, foto_brasao, nome_time)
                    VALUES  
                 ({Id}, @foto_brasao, @nome_time)";

            var response = await connection.ExecuteAsync(query, param);

            if (response > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteTimes(int id_time)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            var param = new DynamicParameters();

            param.Add("id_time", id_time, direction: ParameterDirection.Input);
           

            var query = @"DELETE FROM Times_copa WHERE id_time = @id_time";

            var response = await connection.ExecuteAsync(query, param);
            if(response > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> UpdateTimes(Times model)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            var param = new DynamicParameters();

            param.Add("id_time", model.id_time, direction: ParameterDirection.Input);
            param.Add("foto_brasao", model.foto_brasao, direction: ParameterDirection.Input);
            param.Add("nome_time", model.nome_time, direction: ParameterDirection.Input);

            var query = @"UPDATE Times_copa SET
                      foto_brasao = @foto_brasao,
                      nome_time = @nome_time
                      WHERE
                      id_time = @id_time";

            var responde = await connection.ExecuteAsync(query, param);

            if(responde > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion
    }
}
