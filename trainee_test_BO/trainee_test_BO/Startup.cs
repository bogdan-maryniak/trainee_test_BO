using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trainee_test_BO
{
    public class Startup
    {
        private readonly IWebHostEnvironment Environment;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Create & MigrateDB in prod/state environment
            var connectionString = Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;

            var dbOptions = new DbContextOptionsBuilder<DBContext>();
            dbOptions.UseSqlServer(connectionString);
            using var context = new DBContext(dbOptions.Options);
            context.Database.Migrate();
            #endregion
            #region DI configuration
            Services.Module.Initialize();
            Repositories.Module.Initialize();

           

            services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);          
            foreach (var dep in IoC.IoC.GetSingletons())
                services.AddSingleton(dep.Key, dep.Value);

            foreach (var dep in IoC.IoC.GetScopes())
                services.AddScoped(dep.Key, dep.Value);

            foreach (var dep in IoC.IoC.GetTransinets())
                services.AddTransient(dep.Key, dep.Value);
            #endregion

           
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=Index}/{id?}");
            });
        }
    }
}
