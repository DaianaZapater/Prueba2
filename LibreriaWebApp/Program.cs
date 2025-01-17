using DataAccess;
using Domain.Dtos;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using UsesCases;
using UsesCases.AutoMapper;

namespace LibreriaWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DbContext, Contexto>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("StringConnection"));
            });

            //inyecta el repositorio de tema
            builder.Services.AddScoped(typeof(IRepositoryTema), typeof(RepositorioTema));
            builder.Services.AddScoped(typeof(IServicioTema), typeof(ServicioTema));

            builder.Services.AddScoped(typeof(IRepositoryAutor), typeof(RepositorioAutor));
            builder.Services.AddScoped(typeof(IServicioAutor), typeof(ServicioAutor));
            
            builder.Services.AddScoped(typeof(IRepositoryPais), typeof(RepositorioPais));
            builder.Services.AddScoped(typeof(IServicioPais), typeof(ServicioPais));
            
            builder.Services.AddScoped(typeof(IRepositoryNacionalidad), typeof(RepositorioNacionalidad));
            builder.Services.AddScoped(typeof(IServicioNacionalidad), typeof(ServicioNacionalidad));
            
            builder.Services.AddScoped(typeof(IRepositoryProveedor), typeof(RepositorioProveedor));
            builder.Services.AddScoped(typeof(IServicioProveedor), typeof(ServicioProveedor));

            builder.Services.AddScoped(typeof(IRepositoryEditorial), typeof(RepositorioEditorial));
            builder.Services.AddScoped(typeof(IServicioEditorial), typeof(ServicioEditorial));
            
            builder.Services.AddScoped(typeof(IRepositoryRevista), typeof(RepositorioRevista));
            builder.Services.AddScoped(typeof(IServicioRevista), typeof(ServicioRevista));

            builder.Services.AddScoped(typeof(IRepositoryLibro), typeof(RepositorioLibro));
            builder.Services.AddScoped(typeof(IServicioLibro), typeof(ServicioLibro));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            /***/
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
