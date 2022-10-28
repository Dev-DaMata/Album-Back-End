using Album_Copa.Controllers;
using Album_Copa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace Album_Copa.IRepository
{
    public interface IAtletasRepository
    {
        public Task<List<Atletas>> GetAtletas();
        public Task<Atletas> GetAtleta(int id_atleta);
    }
}
