using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTSAPI.Models;

namespace VTSAPI.DBContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
    }
}
