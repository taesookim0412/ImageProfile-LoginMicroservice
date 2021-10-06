using ImageProfile_Images;
using ImageProfile_Images.Constants;
using ImageProfile_Images.Interfaces;
using ImageProfile_Images.Repositories;
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
        private readonly JwtRepository jwtRepository;
        private readonly UserConstants userConstants;

        public UserRepository(UserReader contextReader, UserWriter contextWriter, UserConstants userConstants, JwtRepository jwtRepository)
        {
            this.contextReader = contextReader;
            this.contextWriter = contextWriter;
            this.jwtRepository = jwtRepository;
            this.userConstants = userConstants;
        }
        //Async DB Call
        public async Task<User> ValidateUser(string username, string password)
        {
            return await (from user in contextReader.Users
                           where (user.username == username && user.password == password)
                           select user).SingleAsync();
        }
        // Async DB Call
        public async Task<bool> FindOneUser(string username)
        {
            //return (context.Users.Where(user => user.username == username).SingleAsync() != null);
            return await ((from user in contextReader.Users
                            where user.username == username
                            select user).SingleAsync()) != null;
        }

        public async Task<CreationStatus> CreateUser(string username, string password)
        {
            if (await FindOneUser(username)) return new CreationStatus(CreationStatus.UsernameExists);
            try
            {
                User user = new User();
                user.username = username;
                user.password = password;
                await contextWriter.AddAsync(user);
                await contextWriter.SaveChangesAsync();
            }
            catch
            {
                return new CreationStatus(CreationStatus.UnknownError);
            }

            //Creation success, generate a jwt.
            string jwtToken = (await jwtRepository.CreateToken(username)).Token;
            return new CreationStatus(CreationStatus.Success, jwtToken);
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
                return string.Join("",
                    userConstants.repeatedAllAsciiChars
                    .Select(bigToken =>
                    {
                        return string.Concat(bigToken.Select(c =>
                         {
                             return bigToken[userConstants.random.Next(bigToken.Length)];
                         }));
                    })
                    );
            });
        }
    }
}
