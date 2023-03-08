using EFCoreApps.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = EFCoreApps.DAL.Entities.Task;

namespace EFCoreApps.DAL
{
    public class TodoDbContext:DbContext
    {

        public TodoDbContext(DbContextOptions<TodoDbContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public DbSet<Tag> Tags{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //before a column must be made unique, it must be indexed
            modelBuilder.Entity<Tag>(e =>
            {
                e.Property(p => p.Name)
                         .IsRequired()
                         .HasMaxLength(20);
                e.HasIndex(p => p.Name, $"IX_{nameof(Tag)}_{nameof(Tag.Name)}")  
                            .IsUnique();



                e.Property(p => p.Description)
                          .HasMaxLength(400);















            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
