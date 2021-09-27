using ImageProfile_Images.Interfaces;
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
        JwtRepository jwtRepository;
        //MyContext context;

        public LoginController(UserRepository userRepository, JwtRepository jwtRepository)
        {
            this.userRepository = userRepository;
            this.jwtRepository = jwtRepository;
        }


        //Input: username, password (bcrypted)
        //Returns: "400: error, 200: jwt token"
        [HttpPost("/login/login")]
        public async Task<ActionResult> Login(string username, string password)
        {
            User result = await userRepository.ValidateUser(username, password);
            if (result == null) { return BadRequest(); }
            return Ok((await jwtRepository.CreateToken(username)).Token);
        }

        //Input: username, password (bcrypted)
        //Returns: True, False, or 400
        [HttpPost("login/create")]
        public async Task<ActionResult> Create(string username, string password)
        {
            CreationStatus creationStatus = await userRepository.CreateUser(username, password);
            if (creationStatus.state == CreationStatus.Success)
            {
                return Ok(await jwtRepository.CreateToken(username));
            }
            return BadRequest();
        }
        [HttpGet("login/createxcsrftoken")]
        //Returns: Csrf String
        public async Task<ActionResult> CreateXCsrfToken()
        {
            return Ok(await userRepository.GetXCsrfToken());
        }
    }
}
