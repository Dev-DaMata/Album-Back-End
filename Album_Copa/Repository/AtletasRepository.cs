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
        public async Task<Atletas> GetAtleta(int id_atleta)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));


            var param = new DynamicParameters();
            param.Add("id_atleta", id_atleta, direction: ParameterDirection.Input);

            var query = @"SELECT * FROM Atletas_copa(nolock) WHERE id_atleta = @id_atleta";

            var response = await connection.QueryFirstAsync<Atletas>(query, param);

            return response;

        }
        public async Task<bool> CreateAtletas(Atletas model)
        {

            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            var param = new DynamicParameters();

            param.Add("id_atleta", model.id_atleta, direction: ParameterDirection.Input);
            param.Add("nome", model.nome, direction: ParameterDirection.Input);
            param.Add("foto", model.foto, direction: ParameterDirection.Input);
            param.Add("pais", model.pais, direction: ParameterDirection.Input);

            var Id = "(SELECT isnull(max(id_atleta),0)+1 AS id_atleta FROM Atletas_copa(nolock))";

            var query = $@"INSERT INTO Atletas_copa (id_atleta, foto, nome, pais)
                    VALUES  
                 ({Id}, @foto, @nome, @pais)";

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
        public async Task<bool> DeleteAtletas(int id_atleta)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            var param = new DynamicParameters();

            param.Add("id_atleta", id_atleta, direction: ParameterDirection.Input);


            var query = @"DELETE FROM Atletas_copa WHERE id_atleta = @id_atleta";

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
        #endregion
    }
}
