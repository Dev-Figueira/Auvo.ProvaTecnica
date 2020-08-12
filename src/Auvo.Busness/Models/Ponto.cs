using System;
using System.Collections.Generic;

namespace Auvo.Busness.Models
{
    public class Ponto : Entity
    {
        public DateTime Data { get; set; }
        public IEnumerable<Registro> Registros { get; set; }
    }
}
