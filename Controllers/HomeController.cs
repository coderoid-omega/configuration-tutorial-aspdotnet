using ConfigExample.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClientDataOption _option;

        //We are usinh IOptions built in class to inject custom Configuration defined in the program.cs file
        public HomeController(IOptions<ClientDataOption> options)
        {
            _option = options.Value;
        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.MyKey = _option.ClientId;
            ViewBag.MyAPIKey = _option.ClientSecret;
            return View();
        }
    }
}
