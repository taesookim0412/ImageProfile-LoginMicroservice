using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProfile_Login.Models
{
    public class UserReader : DbContext
    {
        public UserReader(DbContextOptions<UserReader> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
    }
}
