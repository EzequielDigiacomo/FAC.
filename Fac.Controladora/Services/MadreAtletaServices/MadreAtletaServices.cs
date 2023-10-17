using Fac.AccesoDatos;
using Fac.Controladora.DTOs.AtletaDtos;
using Fac.Controladora.DTOs.MadreAtletaDtos;
using Fac.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.Controladora.Services.MadreAtletaServices
{
    public class MadreAtletaServices : IMadreAtletaServices
    {
        private readonly ApplicationDbContext _context;
        public MadreAtletaServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MadreAtletaDetalleDto>> ObtenerTodos()
        {
            var madresAtletas = await _context.MadreAtletas.Select(m => new MadreAtletaDetalleDto
            {
                Id = m.Id,
                NombreMadre = m.NombreMadre,
                ApellidoMadre = m.ApellidoMadre,
                DniMadre = m.DniMadre,
                CelularDeLaMadre = m.CelularDeLaMadre,
                DireccionDeLaMadre = m.DireccionDeLaMadre,
                EmailDeLaMadre = m.EmailDeLaMadre,
                FotoDniDorsalMadre = m.FotoDniDorsalMadre,
                FotoDniFrontalMadre = m.FotoDniFrontalMadre,

            }).ToListAsync();

            return madresAtletas;
        }

        public async Task<MadreAtletaDetalleDto> ObtenerPorId(int id)
        {
            var madre = await BuscarPorId(id);

            return new MadreAtletaDetalleDto
            {
                Id = madre.Id,
                NombreMadre = madre.NombreMadre,
                ApellidoMadre = madre.ApellidoMadre,
                DniMadre = madre.DniMadre,
                CelularDeLaMadre = madre.CelularDeLaMadre,
                DireccionDeLaMadre = madre.DireccionDeLaMadre,
                EmailDeLaMadre = madre.EmailDeLaMadre,
                FotoDniDorsalMadre = madre.FotoDniDorsalMadre,
                FotoDniFrontalMadre = madre.FotoDniFrontalMadre,
            };
        }

        public async Task<MadreAtletaDetalleDto> Crear(MadreAtletaCrearDto dto)
        {
            var dniRepetido = await _context.MadreAtletas.AnyAsync(x => x.DniMadre == dto.DniMadre);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe una Madre con ese dni {dto.DniMadre}");
            }

            var madreAtleta = new MadreAtleta
            {

                NombreMadre = dto.NombreMadre,
                ApellidoMadre = dto.ApellidoMadre,
                DniMadre = dto.DniMadre,
                CelularDeLaMadre = dto.CelularDeLaMadre,
                DireccionDeLaMadre = dto.DireccionDeLaMadre,
                EmailDeLaMadre = dto.EmailDeLaMadre,
                FotoDniDorsalMadre = dto.FotoDniDorsalMadre,
                FotoDniFrontalMadre = dto.FotoDniFrontalMadre,
            };


            await _context.AddAsync(madreAtleta);
            await _context.SaveChangesAsync();

            return new MadreAtletaDetalleDto
            {
                Id = madreAtleta.Id,
                NombreMadre = madreAtleta.NombreMadre,
                ApellidoMadre = madreAtleta.ApellidoMadre,
                DniMadre = madreAtleta.DniMadre,
                CelularDeLaMadre = madreAtleta.CelularDeLaMadre,
                DireccionDeLaMadre = madreAtleta.DireccionDeLaMadre,
                EmailDeLaMadre = madreAtleta.EmailDeLaMadre,
                FotoDniDorsalMadre = madreAtleta.FotoDniDorsalMadre,
                FotoDniFrontalMadre = madreAtleta.FotoDniFrontalMadre,
            };

        }

        public async Task<MadreAtletaDetalleDto> Actualizar(int id, MadreAtletaCrearDto dto)
        {
            var dniRepetido = await _context.MadreAtletas.AnyAsync(x => x.DniMadre == dto.DniMadre && id != x.Id);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe una Medre con ese dni {dto.DniMadre}");
            }

            var madreAtleta = await BuscarPorId(id);


            madreAtleta.NombreMadre = dto.NombreMadre;
            madreAtleta.ApellidoMadre = dto.ApellidoMadre;
            madreAtleta.DniMadre = dto.DniMadre;
            madreAtleta.CelularDeLaMadre = dto.CelularDeLaMadre;
            madreAtleta.DireccionDeLaMadre = dto.DireccionDeLaMadre;
            madreAtleta.EmailDeLaMadre = dto.EmailDeLaMadre;
            madreAtleta.FotoDniDorsalMadre = dto.FotoDniDorsalMadre;
            madreAtleta.FotoDniFrontalMadre = dto.FotoDniFrontalMadre;


            _context.Update(madreAtleta);
            await _context.SaveChangesAsync();

            return new MadreAtletaDetalleDto
            {
                Id = madreAtleta.Id,
                NombreMadre = madreAtleta.NombreMadre,
                ApellidoMadre = madreAtleta.ApellidoMadre,
                DniMadre = madreAtleta.DniMadre,
                CelularDeLaMadre = madreAtleta.CelularDeLaMadre,
                DireccionDeLaMadre = madreAtleta.DireccionDeLaMadre,
                EmailDeLaMadre = madreAtleta.EmailDeLaMadre,
                FotoDniDorsalMadre = madreAtleta.FotoDniDorsalMadre,
                FotoDniFrontalMadre = madreAtleta.FotoDniFrontalMadre,
            };
        }

        public async Task<MadreAtletaDetalleDto> Remover(int id)
        {
            var madreAtleta = await BuscarPorId(id);
            _context.Remove(madreAtleta);
            await _context.SaveChangesAsync();

            return new MadreAtletaDetalleDto
            {
                Id = madreAtleta.Id,
                NombreMadre = madreAtleta.NombreMadre,
                ApellidoMadre = madreAtleta.ApellidoMadre,
                DniMadre = madreAtleta.DniMadre,
                CelularDeLaMadre = madreAtleta.CelularDeLaMadre,
                DireccionDeLaMadre = madreAtleta.DireccionDeLaMadre,
                EmailDeLaMadre = madreAtleta.EmailDeLaMadre,
                FotoDniDorsalMadre = madreAtleta.FotoDniDorsalMadre,
                FotoDniFrontalMadre = madreAtleta.FotoDniFrontalMadre,
            };
        }


        private async Task<MadreAtleta> BuscarPorId(int id)
        {
            var madre = await _context.MadreAtletas.FindAsync(id);

            if (madre == null)
            {
                throw new Exception($"El atleta con id {id} no existe");
            }

            return madre;
        }
    }
}

