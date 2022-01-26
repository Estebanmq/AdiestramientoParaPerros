using AdiestramientoParaPerros.Data;
using AdiestramientoParaPerros.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //Configuracion de la base de datos
            String cadena = this.Configuration.GetConnectionString("cadenaazureadiestramiento");

            services.AddTransient<RepositoryCitas>();
            services.AddTransient<RepositoryConsultas>();
            services.AddTransient<RepositoryUsuarios>();
            services.AddDbContext<AdiestramientoContext>(options => options.UseSqlServer(cadena));

            //Configuracion del session
            //La memoria distribuida de cache, session comparte informacion con cache para trabajar
            services.AddDistributedMemoryCache();

            //Una sesion funciona por tiempo de inactividad debemos indicar tiempo que duraran los objetos dentro de la sesion
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name : "default" , pattern:"{controller=Home}/{action=Index}"    
                );
            });
        }
    }
}
