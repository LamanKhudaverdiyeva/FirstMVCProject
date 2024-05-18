using FirstMVCProject.Models;
using FirstMVCProject.Repositories;
using FirstMVCProject.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Project.ViewModels;
using Newtonsoft.Json;

namespace FirstMVCProject.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        AppDbContext appDbContext = new AppDbContext();

        public List<Product> GetAllOthersProduct()
        {
            using var dbContext = new AppDbContext();

            var sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("username"));

            return dbContext.Products.Include(x => x.Category).Where(x => x.IsDeleted == false && x.Userid != sessionUser.Userid).ToList();
        }

        public IActionResult Index()
        {
            var products = GetAllOthersProduct();
            return View(products);
        }
        public IActionResult Create()
        {
            CategoryValues();
            return View();
        }


        [NonAction]
        private void CategoryValues()
        {
            List<SelectListItem> categories =
                (from y in appDbContext.Categories.ToList().Where(x => x.IsDeleted == false)
                 select new SelectListItem
                 {
                     Value = y.CategoryID.ToString(),
                     Text = y.Name
                 }).ToList();
            ViewBag.categoryValues = categories;
        }
    }
}

