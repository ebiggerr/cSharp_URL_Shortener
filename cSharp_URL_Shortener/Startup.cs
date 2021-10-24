using cSharp_URL_Shortener.EF;
using cSharp_URL_Shortener.Repository;
using cSharp_URL_Shortener.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace cSharp_URL_Shortener
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
            services.AddControllersWithViews();
            
            services.AddDbContext<cSharp_URL_ShortenerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("URLShortenerDemoDbConnection")));

            services.AddScoped<IRedirectsService, RedirectsService>();
            services.AddScoped<IRedirectsRepo, RedirectsRepo>();
            services.AddScoped<IcSharp_URL_ShortenerDbContext,cSharp_URL_ShortenerDbContext>();

            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddTransient<IStatisticsRepo, StatisticsRepo>();

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
                    pattern: "{controller=Create}/{action=Index}");
            });
        }
    }
}