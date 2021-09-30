using ImageProfile_Login.Models;
using ImageProfile_Login.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProfile_Images.Repositories
{
    public class UserJwtRepository
    {
        UserReader userReader;
        UserRepository userRepository;
        public UserJwtRepository(UserReader userReader, UserRepository userRepository)
        {
            this.userReader = userReader;
            this.userRepository = userRepository;
        }
    }
}
