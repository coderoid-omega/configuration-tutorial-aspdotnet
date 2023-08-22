using ConfigExample.Options;
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
            var clientOptions = _configuration.GetSection("ClientData").Get<ClientDataOption>();
            ViewBag.MyKey = (clientOptions??new ClientDataOption()).ClientId;
            ViewBag.MyAPIKey = _configuration.GetValue<string>("MyAPIKey", "A new key found");
            return View();
        }
    }
}
