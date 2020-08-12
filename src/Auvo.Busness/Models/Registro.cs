using System;
using System.Collections.Generic;
using System.Text;

namespace Auvo.Busness.Models
{
    public class Registro : Entity
    {
        public Guid PontoId { get; set; }
        public string NomeDoColaborador { get; set; }

        public DateTime Horario { get; set; }

        public TipoRegistro TipoDoRegistro { get; set; }

        public Ponto Ponto { get; set; }
    }
}
