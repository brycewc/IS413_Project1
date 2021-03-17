using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Project1.Models
{
    // ITourRepo is a interface. TourGroup is an IQueryable.
    public interface ITourRepo
    {
        IQueryable<TourGroup> TourGroup { get; }
    }
}
