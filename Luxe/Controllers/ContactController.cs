using Microsoft.AspNetCore.Mvc;

namespace Luxe.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
