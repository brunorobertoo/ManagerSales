using ManagerSalesApi.Client;
using ManagerSalesApi.Data;
using ManagerSalesApi.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace ManagerSalesApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>(opt =>
                                               opt.UseMySQL(Configuration.GetConnectionString("ManagerSalesConnection")));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();
            services.AddScoped<RandomUserOpportunityService, RandomUserOpportunityService>();
            services.AddScoped<PublicaCnpjClient, PublicaCnpjClient>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "ManagerSalesApi", 
                    Version = "v1" ,
                    Description = "Aplicação ASP.NET Core Web API para gerenciar Oportunidade de Vendas ",
                    Contact = new OpenApiContact
                    {
                        Name = "Bruno Roberto Oliveira da Silva",
                        Email = "bruno.roberto3br@gmail.com",
                        Url = new System.Uri("https://brunorobertodevweb.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "CC BY",
                        Url = new System.Uri("https://creativecommons.org/licenses/by/4.0")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ManagerSalesApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
