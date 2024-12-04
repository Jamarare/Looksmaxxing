using Looksmaxxing.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looksmaxxing.Data
{
    public class LooksmaxxingContext : IdentityDbContext<ApplicationUser>
    {
        public LooksmaxxingContext(DbContextOptions<LooksmaxxingContext> options) : base(options) {}
        public DbSet<Sigma> Sigmas { get; set; }

        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
    }
}
