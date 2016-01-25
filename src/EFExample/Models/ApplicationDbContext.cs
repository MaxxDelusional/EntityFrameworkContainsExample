using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace EFExample.Models
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<School> Schools { get; set; }

    }
}
