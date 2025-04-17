using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetDrinksWebUI.Controllers;
using DotNetDrinksWebUI.Data;
using DotNetDrinksWebUI.Models;

namespace DotNetDrinksWebUI.Tests
{
    public class ProductsControllerTests
    {
        private AppDbContext GetContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public void Edit_Get_Returns_EditView()
        {
            var ctx = GetContext("EditDb");
            ctx.Products.Add(new Product { Id = 42, Name = "Test" });
            ctx.SaveChanges();

            var ctrl = new ProductsController(ctx);

            var result = ctrl.Edit(42) as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Edit", result.ViewName);
        }

        [Fact]
        public void DeleteConfirmed_Removes_Product()
        {
            var ctx = GetContext("DeleteDb");
            ctx.Products.Add(new Product { Id = 99, Name = "DeleteMe" });
            ctx.SaveChanges();

            var ctrl = new ProductsController(ctx);

            var redirect = ctrl.DeleteConfirmed(99) as RedirectToActionResult;

            Assert.Equal("Index", redirect.ActionName);
            Assert.Null(ctx.Products.Find(99));
        }
    }
}
