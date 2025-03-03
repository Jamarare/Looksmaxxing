using Looksmaxxing.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Looksmaxxing.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Looksmaxxing.Data
{
    public class LooksmaxxingContext : IdentityDbContext<ApplicationUser>
    {
        public LooksmaxxingContext(DbContextOptions<LooksmaxxingContext> options) : base(options) {}
        public DbSet<Sigma> Sigmas { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
