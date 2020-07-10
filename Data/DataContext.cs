using Microsoft.EntityFrameworkCore;
using Online_Exam_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Exam_Management_System.ViewModels;

namespace Online_Exam_Management_System.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating (modelBuilder);

            modelBuilder.Entity<Actor> ()
                .HasMany<User> (u => u.Users)
                .WithOne (a => a.Actor);
            
            //modelBuilder.SeedLoginData();
        }

    }


}
