using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using epjctrip_backend.Models;

    public class TripContext : DbContext
    {
        public TripContext (DbContextOptions<TripContext> options)
            : base(options)
        {
        }

        public DbSet<epjctrip_backend.Models.Plan> Plan { get; set; } = default!;

        public DbSet<epjctrip_backend.Models.Activity> Activity { get; set; } = default!;

        public DbSet<epjctrip_backend.Models.User> User { get; set; } = default!;
    }
