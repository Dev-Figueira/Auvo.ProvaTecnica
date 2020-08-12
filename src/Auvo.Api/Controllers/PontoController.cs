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
    [Route("api/ponto")]
    public class PontoController : MainController
    {
        private readonly IPontoRepository _pontoRepository;
        private readonly IPontoService _pontoService;
        private readonly IMapper _mapper;

        public PontoController(IPontoRepository PontoRepository,
                                      IMapper mapper,
                                      IPontoService PontoService,
                                      INotificador notificador) : base(notificador)
        {
            _pontoRepository = PontoRepository;
            _mapper = mapper;
            _pontoService = PontoService;
        }

        [HttpGet]
        public async Task<IEnumerable<PontoDto>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<PontoDto>>(await _pontoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PontoDto>> ObterPorId(Guid id)
        {
            var ponto = await ObterPontoRegistros(id);

            if (ponto == null) return NotFound();

            return ponto;
        }

        [HttpPost]
        public async Task<ActionResult<PontoDto>> Adicionar(PontoDto pontoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pontoService.Adicionar(_mapper.Map<Ponto>(pontoDto));

            return CustomResponse(pontoDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<PontoDto>> Atualizar(Guid id, PontoDto pontoDto)
        {
            if (id != pontoDto.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na consulta");
                return CustomResponse(pontoDto);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pontoService.Atualizar(_mapper.Map<Ponto>(pontoDto));

            return CustomResponse(pontoDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<PontoDto>> Excluir(Guid id)
        {
            var pontoDto = await ObterPontoRegistros(id);

            if (pontoDto == null) return NotFound();

            await _pontoService.Remover(id);

            return CustomResponse(pontoDto);
        }

        private async Task<PontoDto> ObterPontoRegistros(Guid id)
        {
            return _mapper.Map<PontoDto>(await _pontoRepository.ObterPontoRegistros(id));
        }
    }
}