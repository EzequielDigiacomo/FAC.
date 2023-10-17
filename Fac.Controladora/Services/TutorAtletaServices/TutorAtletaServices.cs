using Fac.AccesoDatos;
using Fac.Controladora.DTOs.PadreAtletaDtos;
using Fac.Controladora.DTOs.TutorAtletaDtos;
using Fac.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.Controladora.Services.TutorAtletaServices
{
    public class TutorAtletaServices : ITutorAtletaServices
    {
        private readonly ApplicationDbContext _context;
        public TutorAtletaServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TutorAtletaDetalleDto>> ObtenerTodos()
        {
            var tutorAtleta = await _context.TutorAtletas.Select(t => new TutorAtletaDetalleDto
            {
                Id = t.Id,
                NombreTutor = t.NombreTutor,
                ApellidoTutor = t.ApellidoTutor,
                DireccionDelTutor = t.DireccionDelTutor,
                DniTutor = t.DniTutor,
                CelularDelTutor = t.CelularDelTutor,
                EmailDelTutor = t.EmailDelTutor,
                FotoDniDorsalTutor = t.FotoDniDorsalTutor,
                FotoDniFrontalTutor = t.FotoDniFrontalTutor,

            }).ToListAsync();

            return tutorAtleta;
        }

        public async Task<TutorAtletaDetalleDto> ObtenerPorId(int id)
        {
            var tutor = await BuscarPorId(id);

            return new TutorAtletaDetalleDto
            {
                Id = tutor.Id,
                NombreTutor = tutor.NombreTutor,
                ApellidoTutor = tutor.ApellidoTutor,
                DireccionDelTutor = tutor.DireccionDelTutor,
                DniTutor = tutor.DniTutor,
                CelularDelTutor = tutor.CelularDelTutor,
                EmailDelTutor = tutor.EmailDelTutor,
                FotoDniDorsalTutor = tutor.FotoDniDorsalTutor,
                FotoDniFrontalTutor = tutor.FotoDniFrontalTutor,
            };
        }

        public async Task<TutorAtletaDetalleDto> Crear(TutorAtletaCrearDto dto)
        {
            var dniRepetido = await _context.TutorAtletas.AnyAsync(x => x.DniTutor == dto.DniTutor);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe un tutor con ese dni {dto.DniTutor}");
            }

            var tutorAtleta = new TutorAtleta
            {
                NombreTutor = dto.NombreTutor,
                ApellidoTutor = dto.ApellidoTutor,
                DireccionDelTutor = dto.DireccionDelTutor,
                DniTutor = dto.DniTutor,
                CelularDelTutor = dto.CelularDelTutor,
                EmailDelTutor = dto.EmailDelTutor,
                FotoDniDorsalTutor = dto.FotoDniDorsalTutor,
                FotoDniFrontalTutor = dto.FotoDniFrontalTutor,
            };


            await _context.AddAsync(tutorAtleta);
            await _context.SaveChangesAsync();

            return new TutorAtletaDetalleDto
            {
                NombreTutor = tutorAtleta.NombreTutor,
                ApellidoTutor = tutorAtleta.ApellidoTutor,
                DireccionDelTutor = tutorAtleta.DireccionDelTutor,
                DniTutor = tutorAtleta.DniTutor,
                CelularDelTutor = tutorAtleta.CelularDelTutor,
                EmailDelTutor = tutorAtleta.EmailDelTutor,
                FotoDniDorsalTutor = tutorAtleta.FotoDniDorsalTutor,
                FotoDniFrontalTutor = tutorAtleta.FotoDniFrontalTutor,
            };

        }

        public async Task<TutorAtletaDetalleDto> Actualizar(int id, TutorAtletaCrearDto dto)
        {
            var dniRepetido = await _context.TutorAtletas.AnyAsync(x => x.DniTutor == dto.DniTutor && id != x.Id);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe un tutor con ese dni {dto.DniTutor}");
            }

            var tutorAtleta = await BuscarPorId(id);


            tutorAtleta.NombreTutor = dto.NombreTutor;
            tutorAtleta.ApellidoTutor = dto.ApellidoTutor;
            tutorAtleta.DireccionDelTutor = dto.DireccionDelTutor;
            tutorAtleta.DniTutor = dto.DniTutor;
            tutorAtleta.CelularDelTutor = dto.CelularDelTutor;
            tutorAtleta.EmailDelTutor = dto.EmailDelTutor;
            tutorAtleta.FotoDniDorsalTutor = dto.FotoDniDorsalTutor;
            tutorAtleta.FotoDniFrontalTutor = dto.FotoDniFrontalTutor;


            _context.Update(tutorAtleta);
            await _context.SaveChangesAsync();

            return new TutorAtletaDetalleDto
            {
                NombreTutor = tutorAtleta.NombreTutor,
                ApellidoTutor = tutorAtleta.ApellidoTutor,
                DireccionDelTutor = tutorAtleta.DireccionDelTutor,
                DniTutor = tutorAtleta.DniTutor,
                CelularDelTutor = tutorAtleta.CelularDelTutor,
                EmailDelTutor = tutorAtleta.EmailDelTutor,
                FotoDniDorsalTutor = tutorAtleta.FotoDniDorsalTutor,
                FotoDniFrontalTutor = tutorAtleta.FotoDniFrontalTutor,
            };
        }

        public async Task<TutorAtletaDetalleDto> Remover(int id)
        {
            var tutorAtleta = await BuscarPorId(id);
            _context.Remove(tutorAtleta);
            await _context.SaveChangesAsync();

            return new TutorAtletaDetalleDto
            {
                Id = tutorAtleta.Id,
                NombreTutor = tutorAtleta.NombreTutor,
                ApellidoTutor = tutorAtleta.ApellidoTutor,
                DireccionDelTutor = tutorAtleta.DireccionDelTutor,
                DniTutor = tutorAtleta.DniTutor,
                CelularDelTutor = tutorAtleta.CelularDelTutor,
                EmailDelTutor = tutorAtleta.EmailDelTutor,
                FotoDniDorsalTutor = tutorAtleta.FotoDniDorsalTutor,
                FotoDniFrontalTutor = tutorAtleta.FotoDniFrontalTutor,
            };
        }


        private async Task<TutorAtleta> BuscarPorId(int id)
        {
            var tutor = await _context.TutorAtletas.FindAsync(id);

            if (tutor == null)
            {
                throw new Exception($"El atleta con id {id} no existe");
            }

            return tutor;
        }
    }
}

