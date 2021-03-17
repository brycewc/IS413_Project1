using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Project1.Models
{
    // This Repo inherits from ITourRepo
    public class EFTourRepo : ITourRepo
    {
        private TourDbContext _context;
        // Initialize Context
        public EFTourRepo(TourDbContext context)
        {
            _context = context;
        }
        // Tour Group and context.Group associated.
        public IQueryable<TourGroup> TourGroup => _context.Group;
    }
}
