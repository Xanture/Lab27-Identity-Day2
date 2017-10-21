using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace lab27_brian.Models
{
    public class lab27_brianContext : DbContext
    {
        public lab27_brianContext (DbContextOptions<lab27_brianContext> options)
            : base(options)
        {
        }

        public DbSet<lab27_brian.Models.LocationPost> LocationPost { get; set; }
    }
}
