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

        public LoginController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        //Input: username, password (bcrypted)
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> Login(string username, string password)
        {
            return await userRepository.ValidateUser(username, password);
        }

        //Input: username, password (bcrypted)
        //Returns: True, False, or 400
        [HttpPost]
        public async Task<ActionResult<string>> Create(string username, string password)
        {
            return await userRepository.CreateUser(username, password);
        }
    }
}
