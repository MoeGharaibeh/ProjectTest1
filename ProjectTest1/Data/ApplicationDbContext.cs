using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectManager> ProjectManagers { get; set; }
        public virtual DbSet<TeamLeader> TeamLeaders { get; set; }
        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Sprint> Sprints { get; set; }
        public virtual DbSet<SprintTask> SprintTasks { get; set; }
        public virtual DbSet<Work> Works { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<ProjectDeveloper> ProjectDevelopers { get; set; }
        //FIle
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProjectDeveloper>().HasKey(x => new { x.DeveloperId, x.ProjectId });

        }
    }
}
