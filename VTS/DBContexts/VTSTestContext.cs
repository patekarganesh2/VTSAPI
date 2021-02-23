using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTS.Models;

namespace VTS.DBContexts
{
    public class VTSTestContext: DbContext
    {
        public VTSTestContext(DbContextOptions<VTSTestContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
    }
}
