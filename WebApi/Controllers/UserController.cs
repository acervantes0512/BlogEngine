using Application.DTOs;
using Application.Implementations;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IGenericService<Post> genericService, IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult> CreateUser(User user)
        {
            await _userService.CreateUserAsync(user);

            return Ok();
        }

    }
}
