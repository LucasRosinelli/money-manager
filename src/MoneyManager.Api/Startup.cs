using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.ApplicationService;
using MoneyManager.Domain.Contracts.ApplicationServices;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Infrastructure.Persistence;
using MoneyManager.Infrastructure.Persistence.DataContexts;
using MoneyManager.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace MoneyManager.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<MoneyManagerContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IUserApplicationService, UserApplicationService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Money Manager",
                    Version = "v1",
                    Description = "Welcome to my personal Money Manager.",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Lucas Rosinelli da Rocha",
                        Email = "contact@lucasrosinelli.com",
                        Url = "http://www.lucasrosinelli.com"
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Money Manager v1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}