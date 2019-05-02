using Microsoft.AspNetCore.Mvc;
using MoneyManager.Api.Models.UserModel;
using MoneyManager.Domain.Commands.UserCommands;
using MoneyManager.Domain.Contracts.ApplicationServices;
using MoneyManager.Domain.DataTransferObjects.UserDataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Api.Controllers
{
    /// <summary>
    /// Contains operations related to users.
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserApplicationService _applicationService;

        public UserController(IUserApplicationService applicationService)
        {
            this._applicationService = applicationService;
        }

        /// <summary>
        /// Gets all users registered.
        /// </summary>
        /// <returns>List of users registered.</returns>
        /// <response code="200">Returns the list of registered users.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<UserDetailDataTransferObject>>> GetAllAsync()
        {
            var users = await this._applicationService.GetAsync();

            return this.Ok(users);
        }

        /// <summary>
        /// Gets detail of a specific user.
        /// </summary>
        /// <param name="identifier">User identifier.</param>
        /// <returns>User details.</returns>
        /// <response code="200">Returns user details.</response>
        /// <response code="404">If the user was not found.</response>
        [HttpGet("{identifier}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<UserDetailDataTransferObject>>> GetAsync(Guid identifier)
        {
            var user = await this._applicationService.GetByIdentifierAsync(identifier);

            if (user == null)
            {
                return this.NotFound();
            }

            return this.Ok(user);
        }

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /user
        ///     {
        ///         "login": "user.login",
        ///         "password": "Userp@ssw0rd",
        ///         "fullName": "User Full Name"
        ///     }
        /// 
        /// </remarks>
        /// <param name="body">User definitions.</param>
        /// <returns>A newly created user.</returns>
        /// <response code="201">Returns the newly created user.</response>
        /// <response code="400">If the user is not created due to wrong or invalid data.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UserDetailDataTransferObject>> CreateAsync(Register body)
        {
            var command = new RegisterCommand(
                login: body.Login,
                password: body.Password,
                fullName: body.FullName
            );

            var user = await this._applicationService.RegisterAsync(command);

            if (user == null)
            {
                return this.BadRequest();
            }

            return this.CreatedAtAction(nameof(this.GetAsync), new { identifier = user.Identifier }, user);
        }

        /// <summary>
        /// Updates user authentication info.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /user/updateAuthInfo/00000000-0000-0000-0000-000000000000
        ///     {
        ///         "login": "new.user.login",
        ///         "password": "nEwUserp@ssw0rd"
        ///     }
        /// 
        /// </remarks>
        /// <param name="identifier">User identifier to be updated.</param>
        /// <param name="body">New user definitions.</param>
        /// <returns></returns>
        /// <response code="204">If the user is successfully updated.</response>
        /// <response code="400">If the user is not updated due to wrong or invalid data.</response>
        [HttpPut("updateAuthInfo/{identifier}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateAuthInfoAsync(Guid identifier, ChangeAuthInfo body)
        {
            var command = new ChangeAuthInfoCommand(
                identifier: identifier,
                login: body.Login,
                password: body.Password
            );

            var user = await this._applicationService.ChangeAuthInfoAsync(command);

            if (user == null)
            {
                return this.BadRequest();
            }

            return this.NoContent();
        }

        /// <summary>
        /// Updates user basic info.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /user/updateBasicInfo/00000000-0000-0000-0000-000000000000
        ///     {
        ///         "fullName": "User Full Name"
        ///     }
        /// 
        /// </remarks>
        /// <param name="identifier">User identifier to be updated.</param>
        /// <param name="body">New user definitions.</param>
        /// <response code="204">If the user is successfully updated.</response>
        /// <response code="400">If the user is not updated due to wrong or invalid data.</response>
        [HttpPut("updateBasicInfo/{identifier}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateBasicInfoAsync(Guid identifier, ChangeBasicInfo body)
        {
            var command = new ChangeBasicInfoCommand(
                identifier: identifier,
                fullName: body.FullName
            );

            var user = await this._applicationService.ChangeBasicInfoAsync(command);

            if (user == null)
            {
                return this.BadRequest();
            }

            return this.NoContent();
        }
    }
}