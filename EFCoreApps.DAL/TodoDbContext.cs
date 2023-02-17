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
    }
}
