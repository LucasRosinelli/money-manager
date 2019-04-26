﻿using Microsoft.AspNetCore.Mvc;
using MoneyManager.Api.Domain.ApplicationServices;
using MoneyManager.Api.Models;
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
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAll()
        {
            var users = await this._applicationService.GetAllAsync();

            var model = new List<UserModel>();

            foreach (var user in users)
            {
                model.Add(UserModel.FromUser(user));
            }

            return this.Ok(model);
        }

        [HttpGet("{identifier}")]
        public async Task<ActionResult<IEnumerable<UserModel>>> Get(Guid identifier)
        {
            var user = await this._applicationService.GetAsync(identifier);

            if (user == null)
            {
                return this.NotFound();
            }

            var model = UserModel.FromUser(user);

            return this.Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Create(UserModel user)
        {
            var newUser = user.ToUser();

            newUser = await this._applicationService.CreateAsync(newUser);

            var model = UserModel.FromUser(newUser);

            return this.CreatedAtAction(nameof(this.Get), new { identifier = newUser.Identifier }, model);
        }

        [HttpPut("{identifier}")]
        public async Task<ActionResult<UserModel>> Update(Guid identifier, UserModel user)
        {
            var changeUser = user.ToUser();

            changeUser = await this._applicationService.UpdateAsync(identifier, changeUser);

            if (changeUser == null)
            {
                return this.BadRequest();
            }

            var model = UserModel.FromUser(changeUser);

            return this.NoContent();
        }
    }
}