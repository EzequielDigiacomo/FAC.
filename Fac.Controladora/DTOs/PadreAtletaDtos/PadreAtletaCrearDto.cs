using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.Controladora.DTOs.PadreAtletaDtos
{
    public class PadreAtletaCrearDto
    {
        public string? NombrePadre { get; set; }
        public string? ApellidoPadre { get; set; }
        public long? DniPadre { get; set; }
        public string? CelularDelPadre { get; set; }
        public string? EmailDelPadre { get; set; }
        public string? DireccionDelPadre { get; set; }
        public string? FotoDniFrontalPadre { get; set; }
        public string? FotoDniDorsalPadre { get; set; }
        public int IdAtleta { get; set; }
    }
}
