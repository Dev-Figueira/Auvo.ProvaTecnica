using Auvo.Busness.Models;
using System;
using System.Threading.Tasks;

namespace Auvo.Busness.Interfaces
{
    public interface IPontoService : IDisposable
    {
        Task<bool> Adicionar(Ponto ponto);
        Task<bool> Atualizar(Ponto ponto);
        Task<bool> Remover(Guid id);
    }
}
