using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Auvo.Busness.Models
{
    public enum TipoRegistro
    {
        Entrada = 1,
        Intervalo,
        [Display(Name = "Retorno Intervalo")]
        Retorno_Intervalo,
        [Display(Name = "Saída")]
        Saida
    }
}
