using Microsoft.AspNetCore.Mvc;
using MoneyManager.Api.Models.AccountModel;
using MoneyManager.Domain.Commands.AccountCommands;
using MoneyManager.Domain.Contracts.ApplicationServices;
using MoneyManager.Domain.DataTransferObjects.AccountDataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Api.Controllers
{
    /// <summary>
    /// Contains operations related to accounts.
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountApplicationService _applicationService;

        public AccountController(IAccountApplicationService applicationService)
        {
            this._applicationService = applicationService;
        }

        /// <summary>
        /// Gets all accounts registered from user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /account/all/00000000-0000-0000-0000-000000000000
        /// 
        /// </remarks>
        /// <param name="user">User identifier.</param>
        /// <returns>List of accounts registered from user.</returns>
        /// <response code="200">Returns the list of registered accounts from user.</response>
        [HttpGet("all/{user}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<AccountDetailDataTransferObject>>> GetAllAsync(Guid user)
        {
            var accounts = await this._applicationService.GetAsync(user);

            return this.Ok(accounts);
        }

        /// <summary>
        /// Gets detail of a specific account.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /account/00000000-0000-0000-0000-000000000000/00000000-0000-0000-0000-000000000000
        /// 
        /// </remarks>
        /// <param name="user">User identifier.</param>
        /// <param name="identifier">Account identifier.</param>
        /// <returns>Account details.</returns>
        /// <response code="200">Returns account details.</response>
        /// <response code="404">If the account was not found.</response>
        [HttpGet("{user}/{identifier}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<AccountDetailDataTransferObject>> GetAsync(Guid user, Guid identifier)
        {
            var account = await this._applicationService.GetByIdentifierAsync(user, identifier);

            if (account == null)
            {
                return this.NotFound();
            }

            return this.Ok(account);
        }

        /// <summary>
        /// Creates an account.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /account
        ///     {
        ///         "user": "00000000-0000-0000-0000-000000000000",
        ///         "shortName": "CC",
        ///         "longName": "Credit Card",
        ///         "color": "#6d2177",
        ///         "icon": "credit-card"
        ///     }
        /// 
        /// </remarks>
        /// <param name="body">Account definitions.</param>
        /// <returns>A newly created account.</returns>
        /// <response code="201">Returns the newly created account.</response>
        /// <response code="400">If the account is not created due to wrong or invalid data.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<AccountDetailDataTransferObject>> CreateAsync(AccountRegister body)
        {
            var command = new RegisterCommand(
                user: body.User,
                shortName: body.ShortName,
                longName: body.LongName,
                color: body.Color,
                icon: body.Icon
            );

            var account = await this._applicationService.RegisterAsync(command);

            if (account == null)
            {
                return this.BadRequest();
            }

            return this.CreatedAtAction(nameof(this.GetAsync), new { user = body.User, identifier = account.Identifier }, account);
        }

        /// <summary>
        /// Updates account info.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /account/00000000-0000-0000-0000-000000000000/00000000-0000-0000-0000-000000000000
        ///     {
        ///         "shortName": "CCV",
        ///         "longName": "Credit Card Visa",
        ///         "color": "#fdb834",
        ///         "icon": "credit-card"
        ///     }
        /// 
        /// </remarks>
        /// <param name="user">User identifier.</param>
        /// <param name="identifier">Account identifier to be updated.</param>
        /// <param name="body">New account definitions.</param>
        /// <returns></returns>
        /// <response code="204">If the account is successfully updated.</response>
        /// <response code="400">If the account is not updated due to wrong or invalid data.</response>
        [HttpPut("{user}/{identifier}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateInfoAsync(Guid user, Guid identifier, AccountChangeInfo body)
        {
            var command = new ChangeInfoCommand(
                user: user,
                identifier: identifier,
                shortName: body.ShortName,
                longName: body.LongName,
                color: body.Color,
                icon: body.Icon
            );

            var account = await this._applicationService.ChangeInfoAsync(command);

            if (account == null)
            {
                return this.BadRequest();
            }

            return this.NoContent();
        }
    }
}