using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vidly_Kurs.Areas.Identity.Data;
using Vidly_Kurs.Models;

[assembly: HostingStartup(typeof(Vidly_Kurs.Areas.Identity.IdentityHostingStartup))]
namespace Vidly_Kurs.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Vidly_KursContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Vidly_KursContextConnection")));

                services.AddDefaultIdentity<Vidly_KursUser>()
                    .AddEntityFrameworkStores<Vidly_KursContext>();
            });
        }
    }
}