using FirstMVCProject.Models;
using FirstMVCProject.Repositories;
using FirstMVCProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCProject.Controllers
{
    public class CategoryController : Controller
    {

        CategoryRepository categoryRepo = new CategoryRepository();
        public IActionResult Index()
        {
            var categories = categoryRepo.GetAllActive();
            return View(categories);
        }

       
        
        

    }

}
