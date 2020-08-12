using Auvo.Busness.Interfaces;
using Auvo.Busness.Models;
using Auvo.Busness.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Auvo.Busness.Services
{
    public class ServicePonto : BaseService, IPontoService
    {
        private readonly IPontoRepository _pontoRepository;

        public ServicePonto(IPontoRepository pontoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _pontoRepository = pontoRepository;
        }

        public async Task<bool> Adicionar(Ponto ponto)
        {
            if (!ExecutarValidacao(new PontoValidation(), ponto)) return false;

            if (_pontoRepository.ObterPorId(ponto.Id) != null)
                return false;

            await _pontoRepository.Adicionar(ponto);
            return true;
        }

        public async Task<bool> Atualizar(Ponto ponto)
        {
            if (!ExecutarValidacao(new PontoValidation(), ponto)) return false;

            await _pontoRepository.Atualizar(ponto);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_pontoRepository.ObterPontoRegistros(id).Result.Registros.Any())
            {
                Notificar("O ponto possui produtos cadastrados!");
                return false;
            }

            await _pontoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _pontoRepository?.Dispose();
        }
    }
}
