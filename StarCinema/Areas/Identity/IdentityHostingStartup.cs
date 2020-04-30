using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarCinema.Areas.Identity.Data;
using StarCinema.Models;

[assembly: HostingStartup(typeof(StarCinema.Areas.Identity.IdentityHostingStartup))]
namespace StarCinema.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<StarCinemaContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("StarCinemaContextConnection")));
                
                services.AddIdentity<StarCinemaUser, IdentityRole>()
                    .AddRoles<IdentityRole>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<StarCinemaContext>();
            });
        }
    }
}