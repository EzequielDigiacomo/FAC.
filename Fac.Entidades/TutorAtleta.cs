using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.Entidades
{
    public class TutorAtleta
    {
        public int Id { get; set; }
        public string? NombreTutor { get; set; }
        public string? ApellidoTutor { get; set; }
        public long? DniTutor { get; set; }
        public string? CelularDelTutor { get; set; }
        public string? EmailDelTutor { get; set; }
        public string? DireccionDelTutor { get; set; }
        public string? FotoDniFrontalTutor { get; set; }
        public string? FotoDniDorsalTutor { get; set; }

        //-----Relaciones----

        public int IdAtleta { get; set; }
        public virtual List<Atleta> AtletaList { get; set;}
    }
}
