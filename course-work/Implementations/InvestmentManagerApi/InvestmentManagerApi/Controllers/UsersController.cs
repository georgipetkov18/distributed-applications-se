﻿using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserManagerApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        [AllowAnonymous]
        [HttpGet("page/{page?}")]
        public async Task<IActionResult> Get(int page = 1)
        {
            return this.Ok(await this._userService.GetUsersAsync(page));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return this.Ok(await this._userService.GetUserAsync(id));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateUserRequest model)
        {
            return this.Ok(await this._userService.CreateUserAsync(model));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CreateUpdateUserRequest model)
        {
            var updatedEntity = await this._userService.UpdateUserAsync(id, model);
            return this.Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this._userService.DeleteUserAsync(id);
            return this.Ok();
        }
    }
}
