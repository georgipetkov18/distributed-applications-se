using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagerClient.Controllers
{
    [Route("[controller]")]
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
