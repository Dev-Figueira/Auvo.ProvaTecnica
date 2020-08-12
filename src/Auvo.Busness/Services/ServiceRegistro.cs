using Auvo.Busness.Interfaces;
using Auvo.Busness.Models;
using Auvo.Busness.Models.Validations;
using System;
using System.Threading.Tasks;

namespace Auvo.Busness.Services
{
    public class ServiceRegistro : BaseService, IRegistroService
    {
        private readonly IRegistroRepository _registroRepository;
        private readonly IPontoRepository _pontoRepository;

        public ServiceRegistro(IRegistroRepository registroRepository,
                               IPontoRepository pontoRepository,
                              INotificador notificador) : base(notificador)
        {
            _registroRepository = registroRepository;
            _pontoRepository = pontoRepository;
        }

        public async Task<bool> Adicionar(Registro registro)
        {
            var dataAtual = DateTime.Now.ToString("yyyy-MM-dd");
            var ponto = _pontoRepository.Buscar(p => p.Data.ToString() == dataAtual);
            if (!ExecutarValidacao(new RegistroValidation(), registro)) return false;

            if(ponto.Result != null)
            {
                foreach (var pontoAtual in ponto.Result)
                {
                    registro.PontoId = pontoAtual.Id;
                }
            }
            else 
            {
                var pontoNew = new Ponto
                {
                    Id = Guid.NewGuid(),
                    Data = DateTime.Now
                };

               await _pontoRepository.Adicionar(pontoNew);
                registro.PontoId = pontoNew.Id;
            }

            registro.Horario = Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss"));

            await _registroRepository.Adicionar(registro);

            return true;
        }

        public async Task Atualizar(Registro registro)
        {
            if (!ExecutarValidacao(new RegistroValidation(), registro)) return;

            await _registroRepository.Atualizar(registro);
        }

        public async Task Remover(Guid id)
        {
            await _registroRepository.Remover(id);
        }

        public void Dispose()
        {
            _registroRepository?.Dispose();
        }
    }
}
