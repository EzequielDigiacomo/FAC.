using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.Entidades
{
    public class Atleta
    {
        public int Id { get; set; }
        public int? MadreAtletaId { get; set; }
        public int? PadreAtletaId { get; set; }
        public int? TutorAtletaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nacionalidad { get; set; }
        public long Dni { get; set; }
        public string? NumeroDePasaporte { get; set; }
        public string Direccion { get; set; }
        public string? EmailDelAtleta { get; set; }
        public DateTime FechaDeNacimientoDelAtleta { get; set; }
        public string? CelularDelAtleta {  get; set; }
        public string Club { get; set; }
        public string? ObraSocial { get; set; }
        public string? NumeroCarnetObraSocial { get; set; }
        public string? PermisoDeViaje {  get; set; }
        public string? Beca {  get; set; }
        public string FotoDniFrontal { get; set; }
        public string FotoDniDorsal { get; set; }
        public string FotoPasaporteFrontal { get; set; }
        public string FotoPasaporteDorsal { get; set; }

        //-----Relaciones



        public virtual MadreAtleta? MadreAtleta { get; set; } 
        public virtual PadreAtleta? PadreAtleta { get; set; } 
        public virtual TutorAtleta? TutorAtleta { get; set; } 
    }
}
