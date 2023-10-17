
using Fac.AccesoDatos;
using Fac.Controladora.Services.AtletaServices;
using Fac.Controladora.Services.MadreAtletaServices;
using Fac.Controladora.Services.PadreServices;
using Fac.Controladora.Services.TutorAtletaServices;
using Microsoft.EntityFrameworkCore;

namespace FAC.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IAtletaServices, AtletaServices>();
            builder.Services.AddScoped<IMadreAtletaServices, MadreAtletaServices>();
            builder.Services.AddScoped<IPadreAtletaServices, PadreAtletaServices>();
            builder.Services.AddScoped<ITutorAtletaServices, TutorAtletaServices>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}