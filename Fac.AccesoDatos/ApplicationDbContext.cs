using Fac.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.AccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<MadreAtleta> MadreAtletas { get; set; }
        public DbSet<PadreAtleta> PadreAtletas { get; set; }
        public DbSet<TutorAtleta> TutorAtletas { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //-------Atleta-----

            modelBuilder.Entity<Atleta>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Atleta>()
                        .Property(x => x.Nombre)
                        .HasMaxLength(20)
                        .IsRequired();

            modelBuilder.Entity<Atleta>()
                        .Property(x => x.Apellido)
                        .HasMaxLength(20)
                        .IsRequired();

            modelBuilder.Entity<Atleta>()
                        .Property(x => x.Nacionalidad)
                        .HasMaxLength(25)
                        .IsRequired();

            modelBuilder.Entity<Atleta>()
                        .Property(x => x.Dni)
                        .HasMaxLength(99_999_999)
                        .IsRequired();

            modelBuilder.Entity<Atleta>()
                        .Property(x => x.NumeroDePasaporte);

            modelBuilder.Entity<Atleta>()
                        .Property(x => x.Direccion)
                        .IsRequired();

            modelBuilder.Entity<Atleta>()
                        .Property(x => x.EmailDelAtleta)
                        .HasMaxLength(35);

            modelBuilder.Entity<Atleta>()
                       .Property(x => x.FechaDeNacimientoDelAtleta)
                       .IsRequired();

            modelBuilder.Entity<Atleta>()
                       .Property(x => x.CelularDelAtleta);
                      

            modelBuilder.Entity<Atleta>()
                       .Property(x => x.Club)
                       .IsRequired();

            modelBuilder.Entity<Atleta>()
                       .Property(x => x.ObraSocial);

            modelBuilder.Entity<Atleta>()
                       .Property(x => x.NumeroCarnetObraSocial);

            modelBuilder.Entity<Atleta>()
                       .Property(x => x.PermisoDeViaje);

            modelBuilder.Entity<Atleta>()
                       .Property(x => x.Beca);

            modelBuilder.Entity<Atleta>()
                       .Property(x => x.FotoDniFrontal)
                       .IsRequired();

            modelBuilder.Entity<Atleta>()
                       .Property(x => x.FotoDniDorsal)
                       .IsRequired();

            modelBuilder.Entity<Atleta>()
                       .Property(x => x.FotoPasaporteFrontal)
                       .IsRequired();

            modelBuilder.Entity<Atleta>()
                       .Property(x => x.FotoPasaporteDorsal)
                       .IsRequired();

            //modelBuilder.Entity<Atleta>()
            //           .Property(x => x.IdMadre);

            //modelBuilder.Entity<Atleta>()
            //           .Property(x => x.IdPadre);

            //modelBuilder.Entity<Atleta>()
            //           .Property(x => x.IdTutor);


            modelBuilder.Entity<Atleta>()
                        .HasOne(m => m.MadreAtleta);
         
            modelBuilder.Entity<Atleta>()
                        .HasOne(p => p.PadreAtleta);

            modelBuilder.Entity<Atleta>()
                        .HasOne(t => t.TutorAtleta);
                        



            //---------Madre---------

            modelBuilder.Entity<MadreAtleta>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<MadreAtleta>()
                        .Property(x => x.NombreMadre)
                        .HasMaxLength(30);     

            modelBuilder.Entity<MadreAtleta>()
                        .Property(x => x.ApellidoMadre)
                        .HasMaxLength(30);

            modelBuilder.Entity<MadreAtleta>()
                        .Property(x => x.DniMadre)
                        .HasMaxLength(99_999_999); 

            modelBuilder.Entity<MadreAtleta>()
                        .Property(x => x.CelularDeLaMadre);

            modelBuilder.Entity<MadreAtleta>()
                        .Property(x => x.EmailDeLaMadre)
                        .HasMaxLength(40);

            modelBuilder.Entity<MadreAtleta>()
                        .Property(x => x.DireccionDeLaMadre);

            modelBuilder.Entity<MadreAtleta>()
                        .Property(x => x.FotoDniFrontalMadre);

            modelBuilder.Entity<MadreAtleta>()
                        .Property(x => x.FotoDniDorsalMadre);

        

            //---------Padre---------

            modelBuilder.Entity<PadreAtleta>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<PadreAtleta>()
                        .Property(x => x.NombrePadre)
                        .HasMaxLength(30);

            modelBuilder.Entity<PadreAtleta>()
                        .Property(x => x.ApellidoPadre)
                        .HasMaxLength(30);

            modelBuilder.Entity<PadreAtleta>()
                        .Property(x => x.DniPadre)
                        .HasMaxLength(99_999_999);

            modelBuilder.Entity<PadreAtleta>()
                        .Property(x => x.CelularDelPadre);

            modelBuilder.Entity<PadreAtleta>()
                        .Property(x => x.EmailDelPadre)
                        .HasMaxLength(40);

            modelBuilder.Entity<PadreAtleta>()
                        .Property(x => x.DireccionDelPadre);

            modelBuilder.Entity<PadreAtleta>()
                        .Property(x => x.FotoDniFrontalPadre);

            modelBuilder.Entity<PadreAtleta>()
                        .Property(x => x.FotoDniDorsalPadre);


            //---------Tutor---------

            modelBuilder.Entity<TutorAtleta>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<TutorAtleta>()
                        .Property(x => x.NombreTutor)
                        .HasMaxLength(30);

            modelBuilder.Entity<TutorAtleta>()
                        .Property(x => x.ApellidoTutor)
                        .HasMaxLength(30);

            modelBuilder.Entity<TutorAtleta>()
                        .Property(x => x.DniTutor)
                        .HasMaxLength(99_999_999);

            modelBuilder.Entity<TutorAtleta>()
                        .Property(x => x.CelularDelTutor);

            modelBuilder.Entity<TutorAtleta>()
                        .Property(x => x.EmailDelTutor)
                        .HasMaxLength(40);

            modelBuilder.Entity<TutorAtleta>()
                        .Property(x => x.DireccionDelTutor);

            modelBuilder.Entity<TutorAtleta>()
                        .Property(x => x.FotoDniFrontalTutor);

            modelBuilder.Entity<TutorAtleta>()
                        .Property(x => x.FotoDniDorsalTutor);


        }
    }
}
