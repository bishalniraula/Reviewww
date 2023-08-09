using Microsoft.AspNetCore.Mvc;

namespace AuthProject.Controllers
{
    public class AccessControllers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
