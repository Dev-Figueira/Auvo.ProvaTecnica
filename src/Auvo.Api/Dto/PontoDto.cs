using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auvo.Api.Dto
{
    public class PontoDto
    {
        public Guid Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Data { get; set; }
        public IEnumerable<RegistroDto> Registros { get; set; }
    }
}
