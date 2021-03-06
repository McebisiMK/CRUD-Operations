using Lulalend.IRepositories;
using Lulalend.IServices;
using Lulalend.Models;
using Lulalend.Repositories;
using Lulalend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lulalend
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
            var connectionString = Configuration.GetConnectionString("PracticeDatabase");
            services.AddDbContext<practiceContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ILecturersRepository, LecturersRepository>();
            services.AddScoped<IStudentsRepository, StudentRepoitory>();
            services.AddScoped<IStudentsService, StudentsService>();
            services.AddScoped<ILecturersService, LecturersService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Lecturers}/{action=Index}/{id?}");
            });
        }
    }
}
