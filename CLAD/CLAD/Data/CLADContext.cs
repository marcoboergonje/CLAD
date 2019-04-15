using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CLAD.Models;

namespace CLAD.Models
{
    public class CLADContext : DbContext
    {
        public CLADContext (DbContextOptions<CLADContext> options)
            : base(options)
        {
        }

        public DbSet<CLAD.Models.Consultant> Consultant { get; set; }

        public DbSet<CLAD.Models.Article> Article { get; set; }

        public DbSet<CLAD.Models.Question> Question { get; set; }
    }
}
