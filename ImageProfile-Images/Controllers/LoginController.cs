using ImageProfile_Login.Models;
using ImageProfile_Login.Repositories;
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
        public string Login(string username, string password)
        {
            return userRepository.ValidateUser(username, password).ToString();
        }

        //Input: username, password (bcrypted)
        [HttpPost]
        public string Create(string username, string password)
        {
            return userRepository.CreateUser(username, password).ToString();
        }
    }
}
