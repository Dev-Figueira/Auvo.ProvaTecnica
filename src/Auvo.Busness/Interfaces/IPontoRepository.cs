using Auvo.Busness.Models;
using System;
using System.Threading.Tasks;

namespace Auvo.Busness.Interfaces
{
    public interface IPontoRepository : IRepository<Ponto>
    {
        Task<Ponto> ObterPontoRegistros(Guid id);
    }
}
