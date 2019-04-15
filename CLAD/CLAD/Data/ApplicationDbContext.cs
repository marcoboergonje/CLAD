using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CLAD.Models;

namespace CLAD.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CLAD.Models.Message> Message { get; set; }
        public DbSet<CLAD.Models.Img> Img { get; set; }
        public DbSet<CLAD.Models.Answer> Answer { get; set; }
        public DbSet<CLAD.Models.Question> Question { get; set; }
    }
}
