using Microsoft.AspNetCore.Mvc;

namespace User_Management.Controllers
{


    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }


    }
}