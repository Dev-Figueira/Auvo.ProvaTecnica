using AutoMapper;
using Auvo.Api.Dto;
using Auvo.Busness.Interfaces;
using Auvo.Busness.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auvo.Api.Controllers
{
    [Route("api/registro")]
    public class RegistroController : MainController
    {
        private readonly IRegistroRepository _registroRepository;
        private readonly IRegistroService _registroService;
        private readonly IMapper _mapper;

        public RegistroController(IRegistroRepository registroRepository,
                                      IMapper mapper,
                                      IRegistroService registroService,
                                      INotificador notificador) : base(notificador)
        {
            _registroRepository = registroRepository;
            _mapper = mapper;
            _registroService = registroService;
        }

        [HttpGet]
        public async Task<IEnumerable<RegistroDto>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<RegistroDto>>(await _registroRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RegistroDto>> ObterPorId(Guid id)
        {
            var registro = await ObterPontoRegistros(id);

            if (registro == null) return NotFound();

            return registro;
        }

        [HttpPost]
        public async Task<ActionResult<RegistroDto>> Adicionar(RegistroDto registroDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _registroService.Adicionar(_mapper.Map<Registro>(registroDto));

            return CustomResponse(registroDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<PontoDto>> Atualizar(Guid id, RegistroDto registroDto)
        {
            if (id != registroDto.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(registroDto);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _registroService.Atualizar(_mapper.Map<Registro>(registroDto));

            return CustomResponse(registroDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<RegistroDto>> Excluir(Guid id)
        {
            var registroDto = await ObterPontoRegistros(id);

            if (registroDto == null) return NotFound();

            await _registroService.Remover(id);

            return CustomResponse(registroDto);
        }

        private async Task<RegistroDto> ObterPontoRegistros(Guid id)
        {
            return _mapper.Map<RegistroDto>(await _registroRepository.ObterRegistroPonto(id));
        }
    }
}
