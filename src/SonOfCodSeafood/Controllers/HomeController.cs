using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SonOfCodSeafood.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SonOfCodSeafood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Member()
        //{
        //    if (User.IsInRole("Admin"))
        //    {
        //        ViewBag.Members = _db.Members.ToList();
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Member(Member member)
        //{
        //    _db.Members.Add(member);
        //    _db.SaveChanges();
        //    return RedirectToAction("Added");
        //}

        //public IActionResult Added()
        //{
        //    return View();
        //}
    }
}
