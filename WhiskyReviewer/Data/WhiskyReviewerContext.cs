using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WhiskyReviewer.Models
{
    public class WhiskyReviewerContext : DbContext
    {
        public WhiskyReviewerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Distillery> Distilleries { get; set; }
    }
}
