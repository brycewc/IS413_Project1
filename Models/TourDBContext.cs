using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Project1.Models
{
    // Inherits from DbContext.
    public class TourDbContext : DbContext
    {
        public TourDbContext(DbContextOptions<TourDbContext> options) : base(options)
        { }
        // Tour Groups are DB set.
        public DbSet<TourGroup> Group { get; set; }
    }
}
