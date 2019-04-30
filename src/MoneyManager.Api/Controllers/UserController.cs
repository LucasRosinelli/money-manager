using Microsoft.AspNetCore.Mvc;
using MoneyManager.Domain.Commands.UserCommands;
using MoneyManager.Domain.Contracts.ApplicationServices;
using MoneyManager.Domain.DataTransferObjects.UserDataTransferObject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserApplicationService _applicationService;

        public UserController(IUserApplicationService applicationService)
        {
            this._applicationService = applicationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetailDataTransferObject>>> GetAll()
        {
            var users = await this._applicationService.Get();

            return this.Ok(users);
        }

        [HttpGet("{identifier}")]
        public async Task<ActionResult<IEnumerable<UserDetailDataTransferObject>>> Get(Guid identifier)
        {
            var user = await this._applicationService.GetByIdentifier(identifier);

            if (user == null)
            {
                return this.NotFound();
            }

            return this.Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDetailDataTransferObject>> Create(RegisterCommand command)
        {
            var user = await this._applicationService.Register(command);

            return this.CreatedAtAction(nameof(this.Get), new { identifier = user.Identifier }, user);
        }

        [HttpPut("updateAuthInfo")]
        public async Task<ActionResult<UserDetailDataTransferObject>> UpdateAuthInfo(ChangeAuthInfoCommand command)
        {
            var user = await this._applicationService.ChangeAuthInfo(command);

            if (user == null)
            {
                return this.BadRequest();
            }

            return this.NoContent();
        }

        [HttpPut("updateBasicInfo")]
        public async Task<ActionResult<UserDetailDataTransferObject>> UpdateBasicInfo(ChangeBasicInfoCommand command)
        {
            var user = await this._applicationService.ChangeBasicInfo(command);

            if (user == null)
            {
                return this.BadRequest();
            }

            return this.NoContent();
        }
    }
}