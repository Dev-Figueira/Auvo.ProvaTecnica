using Auvo.Api.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auvo.App.Services
{
    public interface IPontoService
    {
        Task<IEnumerable<PontoDto>> GetPonto();
        Task<PontoDto> Detalhes(Guid id);
        Task<RegistroDto> Create(RegistroDto pontoDto);
    }
}
