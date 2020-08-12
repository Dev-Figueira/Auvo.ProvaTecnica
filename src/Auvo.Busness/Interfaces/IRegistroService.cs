using Auvo.Busness.Models;
using System;
using System.Threading.Tasks;

namespace Auvo.Busness.Interfaces
{
    public interface IRegistroService : IDisposable
    {
        Task<bool> Adicionar(Registro registro);
        Task Atualizar(Registro registro);
        Task Remover(Guid id);
    }
}
