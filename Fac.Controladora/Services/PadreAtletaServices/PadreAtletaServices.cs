using Fac.AccesoDatos;
using Fac.Controladora.DTOs.MadreAtletaDtos;
using Fac.Controladora.DTOs.PadreAtletaDtos;
using Fac.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.Controladora.Services.PadreServices
{
    public class PadreAtletaServices : IPadreAtletaServices
    {
        private readonly ApplicationDbContext _context;
        public PadreAtletaServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PadreAtletaDetalleDto>> ObtenerTodos()
        {
            var padresAtletas = await _context.PadreAtletas.Select(p => new PadreAtletaDetalleDto
            {
                Id = p.Id,
                NombrePadre = p.NombrePadre,
                ApellidoPadre = p.ApellidoPadre,
                DireccionDelPadre = p.DireccionDelPadre,
                DniPadre = p.DniPadre,
                CelularDelPadre = p.CelularDelPadre,
                EmailDelPadre = p.EmailDelPadre,
                FotoDniDorsalPadre = p.FotoDniDorsalPadre,
                FotoDniFrontalPadre = p.FotoDniFrontalPadre,

            }).ToListAsync();

            return padresAtletas;
        }

        public async Task<PadreAtletaDetalleDto> ObtenerPorId(int id)
        {
            var padre = await BuscarPorId(id);

            return new PadreAtletaDetalleDto
            {
                Id = padre.Id,
                NombrePadre = padre.NombrePadre,
                ApellidoPadre = padre.ApellidoPadre,
                DireccionDelPadre = padre.DireccionDelPadre,
                DniPadre = padre.DniPadre,
                CelularDelPadre = padre.CelularDelPadre,
                EmailDelPadre = padre.EmailDelPadre,
                FotoDniDorsalPadre = padre.FotoDniDorsalPadre,
                FotoDniFrontalPadre = padre.FotoDniFrontalPadre,
            };
        }

        public async Task<PadreAtletaDetalleDto> Crear(PadreAtletaCrearDto dto)
        {
            var dniRepetido = await _context.PadreAtletas.AnyAsync(x => x.DniPadre == dto.DniPadre);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe un Padre con ese dni {dto.DniPadre}");
            }

            var padreAtleta = new PadreAtleta
            {

                NombrePadre = dto.NombrePadre,
                ApellidoPadre = dto.ApellidoPadre,
                DniPadre = dto.DniPadre,
                CelularDelPadre = dto.CelularDelPadre,
                DireccionDelPadre = dto.DireccionDelPadre,
                EmailDelPadre = dto.EmailDelPadre,
                FotoDniDorsalPadre = dto.FotoDniDorsalPadre,
                FotoDniFrontalPadre = dto.FotoDniFrontalPadre,
            };


            await _context.AddAsync(padreAtleta);
            await _context.SaveChangesAsync();

            return new PadreAtletaDetalleDto
            {
                NombrePadre = padreAtleta.NombrePadre,
                ApellidoPadre = padreAtleta.ApellidoPadre,
                DniPadre = padreAtleta.DniPadre,
                CelularDelPadre = padreAtleta.CelularDelPadre,
                DireccionDelPadre = padreAtleta.DireccionDelPadre,
                EmailDelPadre = padreAtleta.EmailDelPadre,
                FotoDniDorsalPadre = padreAtleta.FotoDniDorsalPadre,
                FotoDniFrontalPadre = padreAtleta.FotoDniFrontalPadre,
            };

        }

        public async Task<PadreAtletaDetalleDto> Actualizar(int id, PadreAtletaCrearDto dto)
        {
            var dniRepetido = await _context.PadreAtletas.AnyAsync(x => x.DniPadre == dto.DniPadre && id != x.Id);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe un Padre con ese dni {dto.DniPadre}");
            }

            var padreAtleta = await BuscarPorId(id);


            padreAtleta.NombrePadre = dto.NombrePadre;
            padreAtleta.ApellidoPadre = dto.ApellidoPadre;
            padreAtleta.DniPadre = dto.DniPadre;
            padreAtleta.CelularDelPadre = dto.CelularDelPadre;
            padreAtleta.DireccionDelPadre = dto.DireccionDelPadre;
            padreAtleta.EmailDelPadre = dto.EmailDelPadre;
            padreAtleta.FotoDniDorsalPadre = dto.FotoDniDorsalPadre;
            padreAtleta.FotoDniFrontalPadre = dto.FotoDniFrontalPadre;


            _context.Update(padreAtleta);
            await _context.SaveChangesAsync();

            return new PadreAtletaDetalleDto
            {
                Id = padreAtleta.Id,
                NombrePadre = padreAtleta.NombrePadre,
                ApellidoPadre = padreAtleta.ApellidoPadre,
                DireccionDelPadre = padreAtleta.DireccionDelPadre,
                DniPadre = padreAtleta.DniPadre,
                CelularDelPadre = padreAtleta.CelularDelPadre,
                EmailDelPadre = padreAtleta.EmailDelPadre,
                FotoDniDorsalPadre = padreAtleta.FotoDniDorsalPadre,
                FotoDniFrontalPadre = padreAtleta.FotoDniFrontalPadre,
            };
        }

        public async Task<PadreAtletaDetalleDto> Remover(int id)
        {
            var padreAtleta = await BuscarPorId(id);
            _context.Remove(padreAtleta);
            await _context.SaveChangesAsync();

            return new PadreAtletaDetalleDto
            {
                Id = padreAtleta.Id,
                NombrePadre = padreAtleta.NombrePadre,
                ApellidoPadre = padreAtleta.ApellidoPadre,
                DireccionDelPadre = padreAtleta.DireccionDelPadre,
                DniPadre = padreAtleta.DniPadre,
                CelularDelPadre = padreAtleta.CelularDelPadre,
                EmailDelPadre = padreAtleta.EmailDelPadre,
                FotoDniDorsalPadre = padreAtleta.FotoDniDorsalPadre,
                FotoDniFrontalPadre = padreAtleta.FotoDniFrontalPadre,
            };
        }


        private async Task<PadreAtleta> BuscarPorId(int id)
        {
            var padre = await _context.PadreAtletas.FindAsync(id);

            if (padre == null)
            {
                throw new Exception($"El atleta con id {id} no existe");
            }

            return padre;
        }
    }
}
