using Album_Copa.Controllers;
using Album_Copa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace Album_Copa.IRepository
{
    public interface ITimesRepository
    {
        public Task<List<Times>> GetTimes();
        public Task<Times> GetTime(int id_time);
    }
}
