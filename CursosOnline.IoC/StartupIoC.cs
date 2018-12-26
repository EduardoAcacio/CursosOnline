using CursosOnline.Data.Contextos;
using CursosOnline.Data.Repositorios;
using CursosOnline.Domain._Base;
using CursosOnline.Domain.Cursos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CursosOnline.IoC
{
    public static class StartupIoC
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(configuration["ConnectionString"]));
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            services.AddScoped(typeof(ICursoRepositorio), typeof(CursoRepositorio));
            services.AddScoped<ArmazenadorDeCurso>();
        }
    }
}