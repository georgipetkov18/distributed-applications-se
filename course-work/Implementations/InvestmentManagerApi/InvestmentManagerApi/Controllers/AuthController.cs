using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagerApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthRequest request)
        {
            return Ok(await this._authService.Authenticate(request.Email, request.Password));
        }
    }
}
