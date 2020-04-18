    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarCinema.DataLayer.Abstract;
using StarCinema.DataLayer.Concrete;
using StarCinema.Models;
using StarCinema.Models.CRUDModels.AddressModels;
using StarCinema.Models.CRUDModels.CategoryModels;
using StarCinema.Models.CRUDModels.CinemaHallModels;
using StarCinema.Models.CRUDModels.CinemaModels;
using StarCinema.Models.CRUDModels.CityModels;
using StarCinema.Models.CRUDModels.CommentModels;
using StarCinema.Models.CRUDModels.MovieModels;
using StarCinema.Models.CRUDModels.SeatModels;

namespace StarCinema
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.AllowAnyOrigin());
            });
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Models.StarCinemaContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("StarCinemaContextConnection")));
            services.AddMemoryCache();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICinemaRepository, CinemaRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<CinemaFactory, CinemaFactory>();
            services.AddScoped<CinemaHallFactory, CinemaHallFactory>();
            services.AddScoped<SeatFactory, SeatFactory>();
            services.AddScoped<CategoryFactory, CategoryFactory>();
            services.AddScoped<CityFactory, CityFactory>();
            services.AddScoped<MovieFactory, MovieFactory>();
            services.AddScoped<CommentFactory, CommentFactory>();           
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });            
            app.UseCookiePolicy();

        }
    }
}
