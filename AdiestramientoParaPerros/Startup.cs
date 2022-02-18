using AdiestramientoParaPerros.Data;
using AdiestramientoParaPerros.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
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

            //Configuracion de autorizacion
            services.AddAuthorization(options =>
            {
                options.AddPolicy("PermisosEmpleado",
                    policy =>
                    policy.RequireRole("1", "2"));

                options.AddPolicy("PermisosAdministrador",
                    policy =>
                    policy.RequireRole("2"));

                options.AddPolicy("PermisosCliente",
                    policy =>
                    policy.RequireRole("0"));
            });

            //Configuracion de autenticacion
            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme =
                CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme =
                CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =
                CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
            {
                config.AccessDeniedPath = "/Manage/ErrorAcceso";
            });


            //Configuracion de la base de datos
            String cadena = this.Configuration.GetConnectionString("cadenaazureadiestramiento");

            services.AddTransient<RepositoryCitas>();
            services.AddTransient<RepositoryConsultas>();
            services.AddTransient<RepositoryUsuarios>();
            services.AddTransient<RepositoryEstadisticas>();
            services.AddDbContext<AdiestramientoContext>(options => options.UseSqlServer(cadena));

            //Configuracion del session
            //La memoria distribuida de cache, session comparte informacion con cache para trabajar
            services.AddDistributedMemoryCache();

            //Una sesion funciona por tiempo de inactividad debemos indicar tiempo que duraran los objetos dentro de la sesion
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });

            services.AddControllersWithViews(options => options.EnableEndpointRouting = false).AddSessionStateTempDataProvider();
            
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

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name : "default",
                    template: "{controller=Home}/{action=Index}"
                    );
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name : "default" , pattern:"{controller=Home}/{action=Index}"    
            //    );
            //});
        }
    }
}
