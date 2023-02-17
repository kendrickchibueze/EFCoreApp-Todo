using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApps.DAL
{
    internal class TodoAppDbContextFactory:IDesignTimeDbContextFactory<TodoDbContext>
    {


        public TodoAppDbContextFactory()
        {

        }


     

        public TodoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoDbContext>();
            var ConnectionString = @"Data Source=DESKTOP-HTUFPR1\SQLEXPRESS; Initial Catalog=TodoDB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(ConnectionString);
            Console.WriteLine(ConnectionString);
            return new TodoDbContext(optionsBuilder.Options);
        }
    }
}
