using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LLPApp.Models;

namespace LLPApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LLPApp.Models.Loan> Loans { get; set; }
        public DbSet<LLPApp.Models.Device> Devices { get; set; }
        public DbSet<LLPApp.Models.Student> Students { get; set; }
    }
}
