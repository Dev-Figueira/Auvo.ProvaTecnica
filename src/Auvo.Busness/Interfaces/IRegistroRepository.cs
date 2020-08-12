using Auvo.Busness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auvo.Busness.Interfaces
{
    public interface IRegistroRepository : IRepository<Registro>
    {
        Task<IEnumerable<Registro>> ObterRegistrosPorPonto(Guid pontoId);
        Task<IEnumerable<Registro>> ObterRegistrosPonto();
        Task<Registro> ObterRegistroPonto(Guid id);
    }
}
