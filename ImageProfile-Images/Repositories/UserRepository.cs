using ImageProfile_Images.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ImageProfile_Images.Repositories
{
    public class UserRepository
    {
        private readonly MyContext context;
        public UserRepository(MyContext context)
        {
            this.context = context;
        }
        public string ValidateUser(string username, string password)
        {
            IQueryable<User> result = from user in context.Users
                         where user.username == username
                         where user.password == password
                         select user;
            return "Okay";
        }
        public void CreateUser(string username, string password)
        {
            User user = new User();
            user.username = username;
            user.password = password;
            context.Add(user);
            context.SaveChanges();
        }
        public string SelectAllUsers()
        {
            User[] result = (from user in context.Users
                                       select user).ToArray();
            return JsonSerializer.Serialize(result);
        }
    }
}
