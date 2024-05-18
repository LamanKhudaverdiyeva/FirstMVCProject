using FirstMVCProject.Models;
using FirstMVCProject.Repositories;
using FirstMVCProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FirstMVCProject.Controllers
{
    public class ShopController : Controller
    {
        SalesRepository salesRepository = new();
        ProductRepository productRepository = new();

        UserRepository userRepository = new();

        public IActionResult Buy(int id)
        {
            var data= productRepository.Get(id);
            return View(data);
        }
       


    }
}
