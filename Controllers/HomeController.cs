using Microsoft.AspNetCore.Mvc;

namespace ConfigExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("/")]
        public IActionResult Index()
        {
            //ViewBag.MyKey = _configuration.GetValue<string>("MyKey");
            ViewBag.MyKey = _configuration.GetValue<string>("ClientData:ClientId");
            ViewBag.MyAPIKey = _configuration.GetValue<string>("MyAPIKey", "A new key found");
            return View();
        }
    }
}
