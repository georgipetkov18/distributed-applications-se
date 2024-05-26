using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Auth;
using InvestmentManagerApi.Business.Responses.User;
using InvestmentManagerApi.Shared.Attributes;
using InvestmentManagerApi.Shared.Utils;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagerClient.Controllers
{
    [Route("[action]")]
    [AppAuthorize]
    public class UsersController : Controller
    {
        private readonly string _baseUri = "https://localhost:7160/users";
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Profile(PatchUserRequest request)
        {
            await RequestManager.PatchAsync<PatchUserRequest, UserResponse>($"{_baseUri}/patch/{SessionManager.User.Id}", request, true);
            SessionManager.ResetSession();
            return Redirect("/login");
        }
    }
}
