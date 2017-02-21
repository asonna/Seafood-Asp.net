using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SonOfCodSeafood.Models;
using Microsoft.AspNetCore.Authorization;


namespace SonOfCodSeafood.Controllers
{
    public class MemberListController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //public object UserManager { get; internal set; }
        public MemberListController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Entry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entry(Member newMember)
        {
            newMember.Role = "Admin";
            _db.Members.Add(newMember);
            _db.SaveChanges();
            return RedirectToAction("Index", "MemberList");
        }

        [Authorize]
        public IActionResult Index()
        {
            List<Member> allMembers = _db.Members.ToList();
            return View(allMembers);
        }
    }
}