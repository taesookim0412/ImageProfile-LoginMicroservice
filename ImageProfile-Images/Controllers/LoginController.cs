using ImageProfile_Images.Repositories;
using ImageProfile_Login.Models;
using ImageProfile_Login.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ImageProfile_Login.Controllers
{
    public class LoginController : Controller
    {
        UserRepository userRepository;
        //MyContext context;

        public LoginController(UserRepository userRepository, JwtRepository jwtRepository)
        {
            this.userRepository = userRepository;
        }


        //Input: username, password (bcrypted)
        //Returns: "404: true, 200: error"
        [HttpPost("/login/login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Login(string username, string password)
        {
            User result = await userRepository.ValidateUser(username, password);
            if (result == null) { return new BadRequestResult(); }
            //return new CreatedAtActionResult("login", "login", null, true);
            return Ok(true);
        }

        //Input: username, password (bcrypted)
        //Returns: True, False, or 400
        [HttpPost("login/create")]
        public async Task<ActionResult> Create(string username, string password)
        {
            return Ok(await userRepository.CreateUser(username, password));
        }
        [HttpGet("login/createxcsrftoken")]
        //Returns: Csrf String
        public async Task<ActionResult> CreateXCsrfToken()
        {
            return Ok(await userRepository.GetXCsrfToken());
        }
    }
}
