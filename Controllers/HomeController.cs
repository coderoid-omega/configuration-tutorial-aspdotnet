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
            // In this Configuration will be read from User Secrets
            //To enable user secrets use following command in Powershell or VS terminal
            //dotnet user-secrets init
            //dotnet user-secrets set "ClientData:ClientId" "Client Value in User secrets"
            //dotnet user-secrets list
            
            ViewBag.MyKey = _option.ClientId;
            ViewBag.MyAPIKey = _option.ClientSecret;
            return View();
        }
    }
}
