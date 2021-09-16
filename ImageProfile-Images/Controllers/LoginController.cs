using ImageProfile_Images.Models;
using ImageProfile_Images.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ImageProfile_Images.Controllers
{
    public class LoginController : Controller
    {
        UserRepository userRepository;
        //MyContext context;

        public LoginController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("login")]
        public String login()
        {
            userRepository.CreateUser("a", "b");
            return userRepository.SelectAllUsers();
        }
    }
}
