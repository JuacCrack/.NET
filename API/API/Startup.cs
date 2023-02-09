using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Core.PersonRepository.Interfaces;
using Core.PersonRepository.Implementations;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // ESTE METODO SE ACTIVA AL INICIAR LA API Y AGREGA LOS SERVICIOS DE REPOSITORIO Y DE CONEXION
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MySQLConnection")));//UTILIZA LA CADENA DE CONEXION DE appsettings.json PARA CONECTARSE A MYSQL
            services.AddScoped<IContactRepository, ContactRepository>();//AGREGAMOS LOS SERVICIOS DE REPOSITORIO
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = " API ", Version = "v1" });
            });

            services.AddControllers();
        }

        // ESTE METODO SE ACTIVA AL INICIAR LA API. ESTE METODO CONFIGURA EL METODO HTTP PARA PODER UTILIZAR SWAGGER
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            app.UseHttpsRedirection();

            app.UseCors("MyAllowSpecificOrigins");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Swagger}/{action=Index}/{id?}");
            });
        }
    }
}
