using LMYC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMYC.Models
{
    public class DummyData
    {
        public static void Initialize(ApplicationDbContext db)
        {
                //var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                //var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                //string[] roleNames = { "Admin", "Member" };
                //IdentityResult roleResult;
                //foreach(var roleName in roleNames)
                //{
                //    var roleExist = roleManager.RoleExists(roleName);
                //}
                //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

                //    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                //if (!roleManager.RoleExists("Admin"))
                //{
                //    var role = new IdentityRole();
                //    role.Name = "Admin";
                //    roleManager.Create(role);
                //}
                //var user = new UserMembers
                //{
                //    Id = "1",
                //    UserName = "a",
                //    Email = "a@a.a",
                //    Street = "Street",
                //    City = "City",
                //    Province = "Province",
                //    Country = "Country",
                //    MobileNumber = "MobileNumber",
                //    SailingExperience = 9,
                //    Role = "Admin",
                //};
                //var result = UserManager.Create(user, "P@$$w0rd");
                //if (!UserManager.IsInRole("1", "Admin"))
                //{
                //    var result1 = UserManager.AddToRole("1", "Admin");
                //}

                //if (!roleManager.RoleExists("Member"))
                //{
                //    var role = new IdentityRole();
                //    role.Name = "Member";
                //    roleManager.Create(role);
                //}
                //user = new UserMembers
                //{
                //    Id = "2",
                //    UserName = "m",
                //    Email = "m@m.m",
                //    Street = "Street",
                //    City = "City",
                //    Province = "Province",
                //    Country = "Country",
                //    MobileNumber = "MobileNumber",
                //    SailingExperience = 6,
                //    Role = "Member",
                //};
                //var result3 = UserManager.Create(user, "P@$$w0rd");

                //if (!UserManager.IsInRole("2", "Member"))
                //{
                //    var result4 = UserManager.AddToRole("2", "Member");
                //}

                //context.Boats.AddOrUpdate(t => t.BoatId, getBoats(context).ToArray());

                //context.SaveChanges();
            if (!db.Boats.Any())
            {
                var dateTime = DateTime.Now;
                string dateFormat = dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                db.Boats.Add(new Boat
                {
                    BoatName = "Boaty McBoatface",
                    Picture = "http://www.lonelyplanet.com/news/wp-content/uploads/2015/06/lemur1.jpg",
                    LengthInFeet = 50,
                    Make = "Speedboat",
                    Year = 2014,
                    RecordCreationDate = dateFormat,
                    CreatedBy = "1",
                });

                db.Boats.Add(new Boat
                {
                    BoatName = "Boaty McBoatface Jr.",
                    Picture = "https://media.mnn.com/assets/images/2016/08/sclaters-lemur-closeup.jpg.653x0_q80_crop-smart.jpg",
                    LengthInFeet = 35,
                    Make = "Medium Speedboat",
                    Year = 2016,
                    RecordCreationDate = dateFormat,
                    CreatedBy = "1",
                });

                db.Boats.Add(new Boat
                {
                    BoatName = "Boaty McBoatface Sr.",
                    Picture = "https://haydensanimalfacts.files.wordpress.com/2015/11/red-ruffed-lemur.jpg",
                    LengthInFeet = 70,
                    Make = "Maximum Speedboat",
                    Year = 2004,
                    RecordCreationDate = dateFormat,
                    CreatedBy = "2",
                });
                
                db.SaveChanges();
            }
        }
    }
}
