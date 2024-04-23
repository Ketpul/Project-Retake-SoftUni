using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Contracts;

namespace Project.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IHomeService homeServuce;

        public HomeController(IHomeService _homeServuce)
        { 
            homeServuce = _homeServuce;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await homeServuce.IndexAsync();

            return View(model);
        }


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }
            
            if (statusCode == 404)
            {
                return View("Error404");
            }

            return View();
        }

    }
}
