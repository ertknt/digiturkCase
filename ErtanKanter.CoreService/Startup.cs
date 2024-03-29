using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ertan.Kanter.Repository;
using ErtanKanter.DAL;
using ErtanKanter.Manager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ErtanKanter.CoreService
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
            services.AddDbContext<ArticleContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ArticleDB"]));
            services.AddScoped<IDataRepository<Article>, ArticleManager>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ArticleContext>();
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated(); //uygulama başladığında veritabanı yoksa oluşturur.
            }
        }
    }
}
