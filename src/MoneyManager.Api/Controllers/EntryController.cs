using Microsoft.AspNetCore.Mvc;
using MoneyManager.Api.Models.EntryModel;
using MoneyManager.Domain.Commands.EntryCommands;
using MoneyManager.Domain.Contracts.ApplicationServices;
using MoneyManager.Domain.DataTransferObjects.IncomeDataTransferObjects;
using MoneyManager.Domain.DataTransferObjects.ExpenseDataTransferObjects;
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
    public class EntryController : Controller
    {
        private readonly IIncomeApplicationService _incomeApplicationService;
        private readonly IExpenseApplicationService _expenseApplicationService;

        public EntryController(IIncomeApplicationService incomeApplicationService, IExpenseApplicationService expenseApplicationService)
        {
            this._incomeApplicationService = incomeApplicationService;
            this._expenseApplicationService = expenseApplicationService;
        }

        /// <summary>
        /// Gets all incomes from account.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /entry/income/all/00000000-0000-0000-0000-000000000000
        /// 
        /// </remarks>
        /// <param name="account">Account identifier.</param>
        /// <returns>List of incomes from account.</returns>
        /// <response code="200">Returns the list of incomes from account.</response>
        [HttpGet("income/all/{account}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<IncomeDetailDataTransferObject>>> GetAllIncomeAsync(Guid account)
        {
            var incomes = await this._incomeApplicationService.GetAsync(account);

            return this.Ok(incomes);
        }

        /// <summary>
        /// Gets detail of a specific income.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /entry/income/00000000-0000-0000-0000-000000000000/00000000-0000-0000-0000-000000000000
        /// 
        /// </remarks>
        /// <param name="account">Account identifier.</param>
        /// <param name="identifier">Income identifier.</param>
        /// <returns>Income details.</returns>
        /// <response code="200">Returns income details.</response>
        /// <response code="404">If the income was not found.</response>
        [HttpGet("income/{account}/{identifier}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IncomeDetailDataTransferObject>> GetIncomeAsync(Guid account, Guid identifier)
        {
            var income = await this._incomeApplicationService.GetByIdentifierAsync(account, identifier);

            if (income == null)
            {
                return this.NotFound();
            }

            return this.Ok(income);
        }

        /// <summary>
        /// Creates an income.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /entry/income
        ///     {
        ///         "account": "00000000-0000-0000-0000-000000000000",
        ///         "description": "Salary",
        ///         "date": "2019-04-30",
        ///         "value": 1500.00
        ///     }
        /// 
        /// </remarks>
        /// <param name="body">Account definitions.</param>
        /// <returns>A newly created account.</returns>
        /// <response code="201">Returns the newly created account.</response>
        /// <response code="400">If the account is not created due to wrong or invalid data.</response>
        [HttpPost("income")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IncomeDetailDataTransferObject>> CreateIncomeAsync(EntryRegister body)
        {
            var command = new RegisterCommand(
                account: body.Account,
                description: body.Description,
                date: body.Date,
                value: body.Value
            );

            var income = await this._incomeApplicationService.RegisterAsync(command);

            if (income == null)
            {
                return this.BadRequest();
            }

            return this.CreatedAtAction(nameof(this.GetIncomeAsync), new { account = body.Account, identifier = income.Identifier }, income);
        }

        /// <summary>
        /// Gets all expenses from account.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /entry/expense/all/00000000-0000-0000-0000-000000000000
        /// 
        /// </remarks>
        /// <param name="account">Account identifier.</param>
        /// <returns>List of expenses from account.</returns>
        /// <response code="200">Returns the list of expenses from account.</response>
        [HttpGet("expense/all/{account}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ExpenseDetailDataTransferObject>>> GetAllExpenseAsync(Guid account)
        {
            var expenses = await this._expenseApplicationService.GetAsync(account);

            return this.Ok(expenses);
        }

        /// <summary>
        /// Gets detail of a specific expense.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /entry/expense/00000000-0000-0000-0000-000000000000/00000000-0000-0000-0000-000000000000
        /// 
        /// </remarks>
        /// <param name="account">Account identifier.</param>
        /// <param name="identifier">Expense identifier.</param>
        /// <returns>Expense details.</returns>
        /// <response code="200">Returns expense details.</response>
        /// <response code="404">If the expense was not found.</response>
        [HttpGet("expense/{account}/{identifier}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ExpenseDetailDataTransferObject>> GetExpenseAsync(Guid account, Guid identifier)
        {
            var expense = await this._expenseApplicationService.GetByIdentifierAsync(account, identifier);

            if (expense == null)
            {
                return this.NotFound();
            }

            return this.Ok(expense);
        }

        /// <summary>
        /// Creates an expense.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /entry/expense
        ///     {
        ///         "account": "00000000-0000-0000-0000-000000000000",
        ///         "description": "Salary",
        ///         "date": "2019-04-30",
        ///         "value": 1500.00
        ///     }
        /// 
        /// </remarks>
        /// <param name="body">Account definitions.</param>
        /// <returns>A newly created account.</returns>
        /// <response code="201">Returns the newly created account.</response>
        /// <response code="400">If the account is not created due to wrong or invalid data.</response>
        [HttpPost("expense")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ExpenseDetailDataTransferObject>> CreateExpenseAsync(EntryRegister body)
        {
            var command = new RegisterCommand(
                account: body.Account,
                description: body.Description,
                date: body.Date,
                value: body.Value
            );

            var expense = await this._expenseApplicationService.RegisterAsync(command);

            if (expense == null)
            {
                return this.BadRequest();
            }

            return this.CreatedAtAction(nameof(this.GetExpenseAsync), new { account = body.Account, identifier = expense.Identifier }, expense);
        }
    }
}