using Fathcore.EntityFramework;
using Fathcore.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simantri.Data;
using Simantri.Data.Services;

namespace Simantri
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // DbContext
            services.AddAuditHandler();
            services.AddDbContext<SimantriDbContext>(prop =>
            {
                prop.UseMySQL(Configuration.GetConnectionString("Default"),
                    builder => builder.MigrationsAssembly(typeof(Startup).Namespace));
            });

            // Services
            services.AddGenericCachedRepository(new CacheSetting("simantri.", 60));
            services.Scan(scan => scan.FromApplicationDependencies()
                .AddClasses(classes => classes.AssignableTo(typeof(IDbContext)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
            //    .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
            //        .AsImplementedInterfaces()
            //        .WithScopedLifetime()
            //    .AddClasses(classes => classes.AssignableTo(typeof(ICachedRepository<>)))
            //        .AsImplementedInterfaces()
            //        .WithScopedLifetime());
            services.AddScoped<ConfigService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
