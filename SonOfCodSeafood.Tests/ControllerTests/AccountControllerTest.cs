using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SonOfCodSeafood.Controllers;
using SonOfCodSeafood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SonOfCodSeafood.Tests.ControllerTests
{
    public class AccountControllerTest
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountControllerTest()
        {
        }


        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //Arrange
            AccountController controller = new AccountController(_userManager, _signInManager, _db);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Get_ViewResult_Register_Test()
        {
            //Arrange
            AccountController controller = new AccountController(_userManager, _signInManager, _db);

            //Act
            var result = controller.Register();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Get_ViewResult_Login_Test()
        {
            //Arrange
            AccountController controller = new AccountController(_userManager, _signInManager, _db);

            //Act
            var result = controller.Login();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
