using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class EnrollmentsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}