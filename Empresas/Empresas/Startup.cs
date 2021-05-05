using Empresas.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Empresas.Infra.Data.DataContexts;
using Empresas.Dominio.Interfaces.Handlers;
using Empresas.Dominio.Handlers;
using Empresas.Infra.Data.Repositorio;
using Empresas.Dominio.Interfaces.Repositorios;

namespace Empresas.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //construtor
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Empresas", Version = "v1" });
            });

            #region AppSettings
            AppSettings appSettings = new AppSettings();
            Configuration.Bind(appSettings);
            services.AddSingleton(appSettings);

            #endregion AppSettings

            #region Swagger

            services.AddSwaggerGen(sw =>
            {
                sw.DescribeAllParametersInCamelCase(); //todos os parametros viram camelcase
                sw.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\Swagger.xml"); //onde ele vai buscar o arquivo xml do swagger, onde tem a documentação xml
                sw.SwaggerDoc("EmpresasAPI", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "EmpresasAPI",
                    Description = "Projeto responsável pelo gerenciamento de empresas",
                    Contact = new OpenApiContact
                    {
                        Name = "Camila Barjud",
                        Email = "camila.romero@deal.com.br",
                        Url = new Uri("https://github.com/kbarjud"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Lincença MIT",
                        Url = new Uri("https://github.com/kbarjud/Empresas/blob/main/LICENSE.md"),
                    }
                });
            });

            #endregion Swagger

            #region DataContexts

            services.AddScoped<DataContext>();

            #endregion DataContexts

            #region Handlers

            services.AddTransient<IEmpresaHandler, EmpresaHandler>();

            #endregion

            #region Repositories

            services.AddTransient<IEmpresaRepositorio, EmpresaRepositorio>();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Empresas v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(sw =>
            {
                sw.SwaggerEndpoint("/swagger/v1/swagger.json", "Empresas");
            });
        }
    }
}
