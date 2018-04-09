using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LMYC.Data;
using LMYC.Models;
using LMYC.Services;

namespace LMYC
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseCors("AllowAnyOrigin");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //comment out on first update
            //CreateRoles(serviceProvider).Wait();
            //DummyData.Initialize(context);
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "Member" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            var user1 = new ApplicationUser
            {
                Id = "1",
                UserName = "a",
                Email = "a@a.a",
                Street = "Street",
                City = "City",
                Province = "Province",
                Country = "Country",
                MobileNumber = "MobileNumber",
                SailingExperience = 9,
            };
            var _user = await _userManager.FindByEmailAsync("a@a.a");

            if (_user == null)
            {
                var createUser = await _userManager.CreateAsync(user1, "P@$$w0rd");
                if (createUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user1, "Admin");
                }
            }

            var user2 = new ApplicationUser
            {
                Id = "2",
                UserName = "m",
                Email = "m@m.m",
                Street = "Street",
                City = "City",
                Province = "Province",
                Country = "Country",
                MobileNumber = "MobileNumber",
                SailingExperience = 6,
            };
            _user = await _userManager.FindByEmailAsync("m@m.m");
            if (_user == null)
            {
                var createUser = await _userManager.CreateAsync(user2, "P@$$w0rd");
                if (createUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user2, "Member");
                }
            }
        }
    }
}
