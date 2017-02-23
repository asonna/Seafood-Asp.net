using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SonOfCodSeafood.Models;
using Xunit;
using SonOfCodSeafood.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SonOfCodSeafood.Tests
{
    public class memberTest
    {
        [Fact]
        public void GetEmailMember()
        {
            //Arrange
            var member = new Member();

            //Act
            member.Email = "mart@mart.com";
            var result = member.Email;

            //Assert
            Assert.Equal("mart@mart.com", result);
        }


        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //Arrange
            AccountController controller = new AccountController();

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }


    }
}
