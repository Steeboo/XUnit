using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication19.Controllers;
using WebApplication19.Models;
using Xunit;

namespace Tests
{
    public class HomeControllerTest
    {
        public HomeControllerTest()
        {
        }

        [Fact]
        public void ShouldAddNumbers()
        {
            var controller = new HomeController();
            var result = controller.Add(3, 7);

            Assert.Equal(result, 10);
        }

        [Fact]
        public void ShouldReturnAboutPage()
        {
            var controller = new HomeController();
            var result = controller.About();

            var viewresult = Assert.IsType<ViewResult>(result);
            var message = viewresult.ViewData["Message"];

            Assert.Equal(message, "Your application description page.");
        }

        [Fact]
        public void ShouldReturnTwoStudents()
        {
            var controller = new HomeController();
            var result = controller.Studenten();

            var viewresult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<List<Student>>(viewresult.Model);

            Assert.Equal(model.Count, 2);
        }

        [Fact]
        public void ShouldReturnViewOnTooLongName()
        {
            var controller = new HomeController();
            var student = new Student { Name = "Koning willem alexander aka willempie" };
            controller.ModelState.AddModelError("Error", "Name too long");

            var result = controller.Edit(student);           
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ShouldGiveErrorOnTooLongName()
        {
            var student = new Student { Name = "Koning willem alexander aka willempie" };
            var validations = ValidateModel(student);
            Assert.Equal(validations.Count, 1);
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
