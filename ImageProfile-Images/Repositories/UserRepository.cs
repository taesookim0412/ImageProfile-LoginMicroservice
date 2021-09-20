using ImageProfile_Login.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ImageProfile_Login.Repositories
{
    public class UserRepository
    {
        private readonly MyContext context;
        private string controllerName = "Login";
        public UserRepository(MyContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<string>> ValidateUser(string username, string password)
        {
            User result = (from user in context.Users
                         where (user.username == username && user.password == password)
                         select user).SingleOrDefault();
            if (result == null)
            {
                Console.WriteLine("Ok failed");
                return new BadRequestResult();
            };
            //callerName: "Login", 
            return new CreatedAtActionResult("Login", this.controllerName, null, result);
        }
        public bool FindOneUser(string username)
        {
            return ((from user in context.Users
                    where user.username == username
                     select user).SingleOrDefault() != null);
        }
        public async Task<ActionResult<bool>> CreateUser(string username, string password)
        {
            if (FindOneUser(username)) return false;
            try
            {
                User user = new User();
                user.username = username;
                user.password = password;
                context.Add(user);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
            
            return true;
        }
    }
}
