using Album_Copa.Controllers;
using Album_Copa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace Album_Copa.IRepository
{
    public interface IFigurinhasRepository
    {
        public Task<List<Figurinhas>> GetFigurinhas();
        public Task<Figurinhas> GetFigurinha(int id_figurinha);
        public Task<bool> CreateFigurinhas(Figurinhas model);
        public Task<bool> DeleteFigurinhas(int id_figurinhas);
    }
}
