using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SacMtgPlanner.Models
{
    public class SacMtgPlannerContext : DbContext
    {
        public SacMtgPlannerContext (DbContextOptions<SacMtgPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<SacMtgPlanner.Models.Meeting> Meeting { get; set; }
    }
}
