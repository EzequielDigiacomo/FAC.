using Fac.AccesoDatos;
using Fac.Controladora.DTOs.AtletaDtos;
using Fac.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fac.Controladora.Services.AtletaServices
{
    public class AtletaServices : IAtletaServices
    {
        private readonly ApplicationDbContext _context;
        public AtletaServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AtletaDetalleDto>> ObtenerTodos()
        {
            var atletas = await _context.Atletas.Select(a => new AtletaDetalleDto
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Apellido = a.Apellido,
                Nacionalidad = a.Nacionalidad,
                Dni = a.Dni,
                NumeroDePasaporte = a.NumeroDePasaporte,
                Direccion = a.Direccion,
                EmailDelAtleta = a.EmailDelAtleta,
                FechaDeNacimientoDelAtleta = a.FechaDeNacimientoDelAtleta,
                CelularDelAtleta = a.CelularDelAtleta,
                Club = a.Club,
                ObraSocial = a.ObraSocial,
                NumeroCarnetObraSocial = a.NumeroCarnetObraSocial,
                PermisoDeViaje = a.PermisoDeViaje,
                Beca = a.Beca,
                FotoDniFrontal = a.FotoDniFrontal,
                FotoDniDorsal = a.FotoDniDorsal,
                FotoPasaporteFrontal = a.FotoPasaporteFrontal,
                FotoPasaporteDorsal = a.FotoPasaporteDorsal,
                MadreAtletaId = a.MadreAtletaId,
                PadreAtletaId = a.PadreAtletaId,
                TutorAtletaId = a.TutorAtletaId,

            }).ToListAsync();

            return atletas;
        }

        public async Task<AtletaDetalleDto> ObtenerPorId(int id)
        {
            var atleta = await BuscarPorId(id);

            return new AtletaDetalleDto
            {
                Id = atleta.Id,
                Nombre = atleta.Nombre,
                Apellido = atleta.Apellido,
                Nacionalidad = atleta.Nacionalidad,
                Dni = atleta.Dni,
                NumeroDePasaporte = atleta.NumeroDePasaporte,
                Direccion = atleta.Direccion,
                EmailDelAtleta = atleta.EmailDelAtleta,
                FechaDeNacimientoDelAtleta = atleta.FechaDeNacimientoDelAtleta,
                CelularDelAtleta = atleta.CelularDelAtleta,
                Club = atleta.Club,
                ObraSocial = atleta.ObraSocial,
                NumeroCarnetObraSocial = atleta.NumeroCarnetObraSocial,
                PermisoDeViaje = atleta.PermisoDeViaje,
                Beca = atleta.Beca,
                FotoDniFrontal = atleta.FotoDniFrontal,
                FotoDniDorsal = atleta.FotoDniDorsal,
                FotoPasaporteFrontal = atleta.FotoPasaporteFrontal,
                FotoPasaporteDorsal = atleta.FotoPasaporteDorsal,
                MadreAtletaId = atleta.MadreAtletaId,
                PadreAtletaId = atleta.PadreAtletaId,
                TutorAtletaId = atleta.TutorAtletaId,
            };
        }

        public async Task<AtletaDetalleDto> Crear(AtletaCrearDto dto)
        {
            var dniRepetido = await _context.Atletas.AnyAsync(x => x.Dni == dto.Dni);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe un usuario con ese dni {dto.Dni}");
            }
            //var dniMadre = await _context.Atletas.AnyAsync(x => x.IdMadre  == 0)
            //{
                
            //}

            var atleta = new Atleta
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Nacionalidad = dto.Nacionalidad,
                Dni = dto.Dni,
                NumeroDePasaporte = dto.NumeroDePasaporte,
                Direccion = dto.Direccion,
                EmailDelAtleta = dto.EmailDelAtleta,
                FechaDeNacimientoDelAtleta = dto.FechaDeNacimientoDelAtleta,
                CelularDelAtleta = dto.CelularDelAtleta,
                Club = dto.Club,
                ObraSocial = dto.ObraSocial,
                NumeroCarnetObraSocial = dto.NumeroCarnetObraSocial,
                PermisoDeViaje = dto.PermisoDeViaje,
                Beca = dto.Beca,
                FotoDniFrontal = dto.FotoDniFrontal,
                FotoDniDorsal = dto.FotoDniDorsal,
                FotoPasaporteFrontal = dto.FotoPasaporteFrontal,
                FotoPasaporteDorsal = dto.FotoPasaporteDorsal,
                MadreAtletaId = dto.MadreAtletaId,
                PadreAtletaId = dto.PadreAtletaId,
                TutorAtletaId = dto.TutorAtletaId,
            };


            await _context.AddAsync(atleta);
            await _context.SaveChangesAsync();

            return new AtletaDetalleDto
            {
                Id = atleta.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Nacionalidad = dto.Nacionalidad,
                Dni = dto.Dni,
                NumeroDePasaporte = dto.NumeroDePasaporte,
                Direccion = dto.Direccion,
                EmailDelAtleta = dto.EmailDelAtleta,
                FechaDeNacimientoDelAtleta = dto.FechaDeNacimientoDelAtleta,
                CelularDelAtleta = dto.CelularDelAtleta,
                Club = dto.Club,
                ObraSocial = dto.ObraSocial,
                NumeroCarnetObraSocial = dto.NumeroCarnetObraSocial,
                PermisoDeViaje = dto.PermisoDeViaje,
                Beca = dto.Beca,
                FotoDniFrontal = dto.FotoDniFrontal,
                FotoDniDorsal = dto.FotoDniDorsal,
                FotoPasaporteFrontal = dto.FotoPasaporteFrontal,
                FotoPasaporteDorsal = dto.FotoPasaporteDorsal,
                MadreAtletaId = dto.MadreAtletaId,
                PadreAtletaId = dto.PadreAtletaId,
                TutorAtletaId = dto.TutorAtletaId,

            };

        }

        public async Task<AtletaDetalleDto> Actualizar(int id, AtletaCrearDto dto)
        {
            var dniRepetido = await _context.Atletas.AnyAsync(x => x.Dni == dto.Dni && id != x.Id);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe un Atleta con ese dni {dto.Dni}");
            }

            var atleta = await BuscarPorId(id);

            atleta.Nombre = dto.Nombre;
            atleta.Apellido = dto.Apellido;
            atleta.Nacionalidad = dto.Nacionalidad;
            atleta.Dni = dto.Dni;
            atleta.NumeroDePasaporte = dto.NumeroDePasaporte;
            atleta.Direccion = dto.Direccion;
            atleta.EmailDelAtleta = dto.EmailDelAtleta;
            atleta.FechaDeNacimientoDelAtleta = dto.FechaDeNacimientoDelAtleta;
            atleta.CelularDelAtleta = dto.CelularDelAtleta;
            atleta.Club = dto.Club;
            atleta.ObraSocial = dto.ObraSocial;
            atleta.NumeroCarnetObraSocial = dto.NumeroCarnetObraSocial;
            atleta.PermisoDeViaje = dto.PermisoDeViaje;
            atleta.Beca = dto.Beca;
            atleta.FotoDniFrontal = dto.FotoDniFrontal;
            atleta.FotoDniDorsal = dto.FotoDniDorsal;
            atleta.FotoPasaporteFrontal = dto.FotoPasaporteFrontal;
            atleta.FotoPasaporteDorsal = dto.FotoPasaporteDorsal;
            atleta.MadreAtletaId = dto.MadreAtletaId;
            atleta.PadreAtletaId = dto.PadreAtletaId;
            atleta.TutorAtletaId = dto.TutorAtletaId;



            _context.Update(atleta);
            await _context.SaveChangesAsync();

            return new AtletaDetalleDto
            {
                Id = atleta.Id,
                Nombre = atleta.Nombre,
                Apellido = atleta.Apellido,
                Nacionalidad = atleta.Nacionalidad,
                Dni = atleta.Dni,
                NumeroDePasaporte = atleta.NumeroDePasaporte,
                Direccion = atleta.Direccion,
                EmailDelAtleta = atleta.EmailDelAtleta,
                FechaDeNacimientoDelAtleta = atleta.FechaDeNacimientoDelAtleta,
                CelularDelAtleta = atleta.CelularDelAtleta,
                Club = atleta.Club,
                ObraSocial = atleta.ObraSocial,
                NumeroCarnetObraSocial = atleta.NumeroCarnetObraSocial,
                PermisoDeViaje = atleta.PermisoDeViaje,
                Beca = atleta.Beca,
                FotoDniFrontal = atleta.FotoDniFrontal,
                FotoDniDorsal = atleta.FotoDniDorsal,
                FotoPasaporteFrontal = atleta.FotoPasaporteFrontal,
                FotoPasaporteDorsal = atleta.FotoPasaporteDorsal,
                MadreAtletaId = atleta.MadreAtletaId,
                PadreAtletaId = atleta.PadreAtletaId,
                TutorAtletaId = atleta.TutorAtletaId,

            };
        }

        public async Task<AtletaDetalleDto> Remover(int id)
        {
            var atleta = await BuscarPorId(id);
            _context.Remove(atleta);
            await _context.SaveChangesAsync();

            return new AtletaDetalleDto
            {
                Id = atleta.Id,
                Nombre = atleta.Nombre,
                Apellido = atleta.Apellido,
                Nacionalidad = atleta.Nacionalidad,
                Dni = atleta.Dni,
                NumeroDePasaporte = atleta.NumeroDePasaporte,
                Direccion = atleta.Direccion,
                EmailDelAtleta = atleta.EmailDelAtleta,
                FechaDeNacimientoDelAtleta = atleta.FechaDeNacimientoDelAtleta,
                CelularDelAtleta = atleta.CelularDelAtleta,
                Club = atleta.Club,
                ObraSocial = atleta.ObraSocial,
                NumeroCarnetObraSocial = atleta.NumeroCarnetObraSocial,
                PermisoDeViaje = atleta.PermisoDeViaje,
                Beca = atleta.Beca,
                FotoDniFrontal = atleta.FotoDniFrontal,
                FotoDniDorsal = atleta.FotoDniDorsal,
                FotoPasaporteFrontal = atleta.FotoPasaporteFrontal,
                FotoPasaporteDorsal = atleta.FotoPasaporteDorsal,
                MadreAtletaId = atleta.MadreAtletaId,
                PadreAtletaId = atleta.PadreAtletaId,
                TutorAtletaId = atleta.TutorAtletaId,
            };
        }


        private async Task<Atleta> BuscarPorId(int id)
        {
            var atleta = await _context.Atletas.FindAsync(id);

            if (atleta == null)
            {
                throw new Exception($"El atleta con id {id} no existe");
            }

            return atleta;
        }
    }

}

