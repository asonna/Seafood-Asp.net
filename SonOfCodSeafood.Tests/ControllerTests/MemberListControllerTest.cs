using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SonOfCodSeafood.Controllers;
using SonOfCodSeafood.Models;
using Xunit;
using Microsoft.AspNetCore.Identity;

namespace SonOfCodSeafood.Tests.ControllerTests
{
    public class MemberListControllerTest
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //public MemberListControllerTest()
        //{
        //}

        [Fact]
        public void Get_ViewResult_Join_Test()
        {
            //Arrange
            MemberListController controller = new MemberListController(_userManager, _signInManager, _db);

            //Act
            var result = controller.Entry();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Get_ModelList_List_Test()
        {
            //Arrange
            MemberListController controller = new MemberListController(_userManager, _signInManager, _db);
            IActionResult actionResult = controller.List();
            ViewResult listView = controller.List() as ViewResult;

            //Act
            var result = listView.ViewData.Model;

            //Assert
            Assert.IsType<List<Member>>(result);
        }

    }
}
