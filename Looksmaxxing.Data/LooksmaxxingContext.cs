using Looksmaxxing.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looksmaxxing.Data
{
    public class LooksmaxxingContext : DbContext
    {
        public LooksmaxxingContext(DbContextOptions<LooksmaxxingContext> options) : base(options) {}
        public DbSet<Sigma> Sigmas { get; set; }
    }
}
