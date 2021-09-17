using ImageProfile_Login.Models;
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
        public UserRepository(MyContext context)
        {
            this.context = context;
        }
        public bool ValidateUser(string username, string password)
        {
            User result = (from user in context.Users
                         where (user.username == username && user.password == password)
                         select user).SingleOrDefault();
            return result != null;
        }
        public bool FindOneUser(string username)
        {
            return ((from user in context.Users
                    where user.username == username
                     select user).SingleOrDefault() != null);
        }
        public bool CreateUser(string username, string password)
        {
            if (FindOneUser(username)) return false;
            User user = new User();
            user.username = username;
            user.password = password;
            context.Add(user);
            context.SaveChanges();
            return true;
        }
    }
}
