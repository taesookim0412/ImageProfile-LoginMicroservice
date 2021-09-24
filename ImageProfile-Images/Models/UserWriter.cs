using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProfile_Login.Models
{
    public class UserWriter : DbContext
    {
        public UserWriter(DbContextOptions<UserWriter> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
    }
}
