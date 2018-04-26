using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiskyReviewer.Models;

namespace WhiskyReviewer.Models
{
    public class WhiskyReviewerContext : DbContext
    {
        public WhiskyReviewerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Distillery> Distilleries { get; set; }

        public DbSet<WhiskyReviewer.Models.Whisky> Whisky { get; set; }
    }
}
