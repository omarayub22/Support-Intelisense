using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SupportIntelisense.Areas.Identity;
using SupportIntelisense.Models;

namespace SupportIntelisense.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Associate> Associate { get; set; }
        public DbSet<Originator> Originator { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<Status> Status { get; set; }

    }
}
