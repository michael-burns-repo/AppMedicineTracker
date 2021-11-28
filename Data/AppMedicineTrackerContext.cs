using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppMedicineTracker.Models;

    public class AppMedicineTrackerContext : DbContext
    {
        public AppMedicineTrackerContext (DbContextOptions<AppMedicineTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<AppMedicineTracker.Models.Medicine> Medicine { get; set; }
    }
