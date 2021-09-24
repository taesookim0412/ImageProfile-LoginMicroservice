using ImageProfile_Login.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ImageProfile_Login.Repositories
{
    public class UserRepository
    {
        private readonly UserReader contextReader;
        private readonly UserWriter contextWriter;
        private string controllerName = "Login";
        public UserRepository(UserReader contextReader, UserWriter contextWriter)
        {
            this.contextReader = contextReader;
            this.contextWriter = contextWriter;
        }
        //Async DB Call
        public async Task<User> ValidateUser(string username, string password)
        {
            return (await (from user in contextReader.Users
                           where (user.username == username && user.password == password)
                           select user).SingleAsync());
        }
        // Async DB Call
        public async Task<bool> FindOneUser(string username)
        {
            //return (context.Users.Where(user => user.username == username).SingleAsync() != null);
            return (await ((from user in contextReader.Users
                    where user.username == username
                    select user).SingleAsync())!= null);
        }

        public async Task<ActionResult<bool>> CreateUser(string username, string password)
        {
            if (await FindOneUser(username)) return new CreatedAtActionResult("Create", this.controllerName, null, false);
            try
            {
                User user = new User();
                user.username = username;
                user.password = password;
                await contextWriter.AddAsync(user);
                await contextWriter.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
            
            return new CreatedAtActionResult("Create", this.controllerName, null, true);
        }
        //TODO: Convert this to grpc, use rsa keys instead
        //Returns an async task synchronously to the controller
        public async Task<string> GetXCsrfToken()
        {
            return await GenerateXCsrfToken();
        }
        //CPU-intensive: create and await an async Task 
        public async Task<string> GenerateXCsrfToken()
        {
            return await Task.Run(() =>
            {
                string allAsciiChars = "!\"#$%&\\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]^_`abcdefghijklmnopqrstuvwxyz{|}~";
                Random random = new Random();
                string resultToken = new string(
                   Enumerable.Repeat(allAsciiChars, 64)
                   .Select(token => token[random.Next(token.Length)]).ToArray());
                return resultToken.ToString();
            });
        }
    }
}
