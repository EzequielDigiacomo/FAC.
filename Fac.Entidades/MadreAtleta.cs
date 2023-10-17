using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.Entidades
{
    public class MadreAtleta
    {
        public int Id { get; set; }
        public string? NombreMadre { get; set; }
        public string? ApellidoMadre { get; set; }
        public long? DniMadre { get; set; }
        public string? CelularDeLaMadre { get; set; }
        public string? EmailDeLaMadre { get; set; }
        public string? DireccionDeLaMadre { get; set; }
        public string? FotoDniFrontalMadre { get; set; }
        public string? FotoDniDorsalMadre { get; set; }

        //------Relaciones
        public int IdAtleta { get; set; }
        public virtual List<Atleta> AtletaList { get; set; }

        
    }
}
