using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMYC.Data;
using LMYC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace LMYC.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationUsers
        public async Task<IActionResult> Index()
        {
            UserAndRolesHelper viewModel = new UserAndRolesHelper();
            viewModel.FirstTable = _context.Users.ToList();
            var users = _context.Users.ToList();
            var roles = _context.Roles.ToList();
            var userAndRoles = _context.UserRoles.ToList();

            List<KeyValuePair<String, String>> ListOfUsersAndRoles = new List<KeyValuePair<String, String>>();
            foreach(var userAndRole in userAndRoles)
            {
                String username = "";
                String roleName = "";
                foreach(var user in users)
                {
                    if(userAndRole.UserId == user.Id)
                    {
                        username = user.UserName;
                        break;
                    }
                }
                foreach(var role in roles)
                {
                    if(userAndRole.RoleId == role.Id)
                    {
                        roleName = role.Name;
                    }
                }
                var element = new KeyValuePair<String, String>(username, roleName);
                ListOfUsersAndRoles.Add(element);
            }
            
            viewModel.SecondTable = ListOfUsersAndRoles;
            viewModel.ThirdTable = roles;
            return View(viewModel);
        }

        // GET: ApplicationUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.AppUsers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        //// GET: ApplicationUsers/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ApplicationUsers/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Firstname,LastName,Street,City,Province,PostalCode,Country,MobileNumber,SailingExperience,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(applicationUser);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(applicationUser);
        //}

        [Authorize(Roles = "Admin")]
        // GET: ApplicationUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (User.Identity.GetUserId() != "1")
            {
                return StatusCode((int)(HttpStatusCode.Forbidden), "Not allowed to add main Admin's roles.");
            }
            var applicationUser = await _context.AppUsers.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            //var roles = _context.Roles.ToList();

            //applicationUser.allUserRoles = new List<SelectListItem>();

            //foreach (var role in roles)
            //{
            //    var item = new SelectListItem { Value = role.Name, Text = role.Name };
            //    applicationUser.allUserRoles.Add(item);
            //}
            var roles = _context.Roles.ToList();
            var users = _context.Users.ToList();
            var userAndRoles = _context.UserRoles.ToList();
            applicationUser.allUserRoles = new List<SelectListItem>();
            var tracked = new List<String>();

            foreach (var userAndRole in userAndRoles)
            {
                if (userAndRole.UserId == id)
                {
                    foreach (var role in roles)
                    {
                        if (userAndRole.RoleId == role.Id)
                        {
                            tracked.Add(userAndRole.RoleId);
                            break;
                        }
                    }
                }
            }

            foreach(var role in roles)
            {
                if(!tracked.Contains(role.Id))
                {
                    var item = new SelectListItem { Value = role.Name, Text = role.Name };
                    applicationUser.allUserRoles.Add(item);
                }
            }

            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, string Roles, [Bind("Firstname,LastName,Street,City,Province,PostalCode,Country,MobileNumber,SailingExperience,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Roles != null)
                    {
                        var roleList = _context.Roles.ToList();
                        String roleId = "";
                        foreach (var role in roleList)
                        {
                            if (role.Name == Roles)
                            {
                                roleId = role.Id;
                                break;
                            }
                        }

                        _context.Update(applicationUser);
                        var userAndRole = new Microsoft.AspNetCore.Identity.IdentityUserRole<string>();
                        userAndRole.UserId = id;
                        userAndRole.RoleId = roleId;

                        if (_context.UserRoles.Find(id, roleId) != null)
                        {

                        }
                        else
                        {
                            _context.UserRoles.Add(userAndRole);
                        }
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        [Authorize(Roles = "Admin")]
        // GET: ApplicationUsers/Remove/5
        public async Task<IActionResult> Remove(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id == "1")
            {
                if (User.Identity.GetUserId() != "1") { 
                    return StatusCode((int)(HttpStatusCode.Forbidden), "Not allowed to remove main Admin's roles.");
                }
            }
            var applicationUser = await _context.AppUsers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            var roles = _context.Roles.ToList();
            var users = _context.Users.ToList();
            var userAndRoles = _context.UserRoles.ToList();
            applicationUser.allUserRoles = new List<SelectListItem>();

            foreach (var userAndRole in userAndRoles)
            {
                if (userAndRole.UserId == id)
                {
                    foreach (var role in roles)
                    {
                        if (userAndRole.RoleId == role.Id)
                        {
                            var item = new SelectListItem { Value = role.Name, Text = role.Name };
                            applicationUser.allUserRoles.Add(item);
                            break;
                        }
                    }
                }
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Remove/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(string id, string Roles, [Bind("Firstname,LastName,Street,City,Province,PostalCode,Country,MobileNumber,SailingExperience,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(Roles != null) { 
                        var roleList = _context.Roles.ToList();
                        String roleId = "";
                        foreach (var role in roleList)
                        {
                            if (role.Name == Roles)
                            {
                                roleId = role.Id;
                                break;
                            }
                        }

                        _context.Update(applicationUser);
                        var userAndRole = new Microsoft.AspNetCore.Identity.IdentityUserRole<string>();
                        userAndRole.UserId = id;
                        userAndRole.RoleId = roleId;
                        var entry = _context.UserRoles.Find(id, roleId);
                        if (entry != null)
                        {
                            _context.Entry(entry).State = EntityState.Deleted;
                        }
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.AppUsers.Any(e => e.Id == id);
        }
    }
}
