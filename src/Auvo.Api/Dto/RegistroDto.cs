using Auvo.Busness.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Auvo.Api.Dto
{
    public class RegistroDto
    {
        public Guid Id { get; set; }

        public Guid PontoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Nome do Colaborador")]
        public string NomeDoColaborador { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        [DisplayName("Horário")]
        public DateTime Horario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public TipoRegistro TipoDoRegistro { get; set; }

        public  PontoDto Ponto { get; set; }
    }
}
