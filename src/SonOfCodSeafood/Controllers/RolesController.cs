﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SonOfCodSeafood.Models;
using Microsoft.AspNetCore.Identity;
using SonOfCodSeafood.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SonOfCodSeafood.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RolesController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var roles = _db.Roles.ToList();
            return View(roles);
        }
        // GET: /Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public IActionResult Create(string RoleName)
        {
            try
            {
                _db.Roles.Add(new Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole()
                {
                    Name = RoleName
                });
                _db.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(string RoleName)
        {
            var thisRole = _db.Roles.FirstOrDefault(r => r.Name == RoleName);
            _db.Roles.Remove(thisRole);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Roles/Edit/5
        public IActionResult Edit(string roleId)
        {
            var thisRole = _db.Roles.FirstOrDefault(r => r.Id == roleId);

            return View(thisRole);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole role)
        {
            try
            {
                var thisRole = _db.Roles.FirstOrDefault(r => r.Id == role.Id);
                thisRole.Name = role.Name;
                _db.Entry(thisRole).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");

            }

            catch (DbUpdateConcurrencyException)
            {
                return View();
            }
        }

        public IActionResult ManageUserRoles()
        {
            // prepopulat roles for the view dropdown
            var list = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Id.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoleAddToUser(string UserName, string RoleId)
        {
            try
            {
                ApplicationUser user = _db.Users.FirstOrDefault(u => u.UserName == UserName);
                var task = await _userManager.AddToRoleAsync(user, RoleId);

            }
            catch (Exception)
            {
                return View();
            }
            ViewBag.ResultMessage = "Role created successfully !";

            // prepopulat roles for the view dropdown
            var list = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Id.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            return View("ManageUserRoles");
        }


    }
}
