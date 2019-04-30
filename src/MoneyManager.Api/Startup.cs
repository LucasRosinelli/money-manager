using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.ApplicationService;
using MoneyManager.Domain.Contracts.ApplicationServices;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Infrastructure.Persistence.DataContexts;
using MoneyManager.Infrastructure.Repositories;

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
            services.AddDbContext<MoneyManagerDbContext>(options =>
            {
                options.UseInMemoryDatabase("money-manager");
            });

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserApplicationService, UserApplicationService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
        }
    }
}