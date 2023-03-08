using EFCoreApps.DAL.Entities;

namespace EFCoreApp
{
    internal class Program
    {
        static async Task Main()
        {
            ToDoAppDbContextFactory toDoAppDbContextFactory = new ToDoAppDbContextFactory();
            var dbContext = toDoAppDbContextFactory.CreateDbContext(null);



            bool anyUser = await dbContext.Users.AnyAsync();

            if (!anyUser)
            {
                List<User> users = new List<User>()
            {
                new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "09087652123",
                    Email = "john.doe@domain.com",
                    Birthday = new DateTime(2001, 1,1),
                    Created = DateTime.Now,
                    IsActive = true
                },

                new User
                {
                    FirstName = "Mary",
                    LastName = "Doe",
                    PhoneNumber = "09087652121",
                    Email = "mary.doe@domain.com",
                    Birthday = new DateTime(2005, 1,1),
                    Created = DateTime.Now.AddYears(-4),
                    Updated = DateTime.Now
                },

                new User
                {
                    FirstName = "David",
                    LastName = "Doe",
                    MiddleName = "Bello",
                    PhoneNumber = "09087652120",
                    Email = "david.doe@domain.com",
                    Birthday = new DateTime(2001, 1,1),
                    Created = DateTime.Now.AddYears(-2),
                    Updated = DateTime.Now,
                    IsActive = true
                }
            };

                // AddRange
                Console.WriteLine("Create Users============");
                await dbContext.Users.AddRangeAsync(users);
                Console.WriteLine(await dbContext.SaveChangesAsync());
            }



            Console.WriteLine("Fetch All Users==========");

            var allUsers = await dbContext.Users.ToListAsync();

            foreach (var user in allUsers)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName} {user.Id}");
            }

            Console.WriteLine("Fetch All Active Users==========");


            var activeUsers = await dbContext.Users.Where(u => u.IsActive && u.Updated == null).ToListAsync();


            foreach (var user in activeUsers)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName} {user.Id}");
            }

            Console.WriteLine("Scalars=======");
            Console.WriteLine($"Max:{await dbContext.Users.MaxAsync(u => u.Birthday)}");

            var youngest = await dbContext.Users.OrderByDescending(u => u.Birthday).FirstOrDefaultAsync();
            Console.WriteLine($"Youngest: {youngest?.FirstName} {youngest?.LastName}");


            var oldest = await dbContext.Users.OrderBy(u => u.Birthday).FirstOrDefaultAsync();
            Console.WriteLine($"Oldest: {oldest?.FirstName ?? "not found"} {oldest?.LastName ?? "not found"}");


            // deferred
            IQueryable<User> userQuery = dbContext.Users.OrderByDescending(u => u.Birthday);

            // await dbContext.SaveChangesAsync();


            Console.WriteLine("Update=================");

            var userToUpdate = await dbContext.Users.SingleOrDefaultAsync(u => u.FirstName.ToLower() == "john");
            // var userToUpdate = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == 3);

            if (userToUpdate != null)
            {
                userToUpdate.FirstName = "Caleb";

                var msg = await dbContext.SaveChangesAsync() > 0 ? "Update Successful" : "Update Failed";

                Console.WriteLine(msg);
            }

            var userToDelete = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == 2);


            if (userToDelete != null)
            {
                dbContext.Users.Remove(userToDelete);

                var msg = await dbContext.SaveChangesAsync() > 0 ? "Delete Successful" : "Delete Failed";

                Console.WriteLine(msg);
            }


            // var demo = new User
            // {
            //     FirstName = "Amaka",
            //     LastName = "Ben",
            //     Birthday = new DateTime(1990, 01, 20),
            //     Email = "amaka.ben@yahoo.com",
            //     IsActive = true,
            //     PhoneNumber = "08144217359",
            //     Created = DateTime.Now,
            //
            //     Tasks = new List<EfcoreApp.DAL.Entities.Task>()
            //     {
            //
            //         new EfcoreApp.DAL.Entities.Task()
            //         {
            //             Name = "Hiking",
            //             Description = "Blala Blue",
            //             Tags = new List<Tag>()
            //             {
            //                 new Tag()
            //                 {
            //                     Name = "OutDoor"
            //                 },
            //
            //                 new Tag()
            //                 {
            //                     Name = "Activity"
            //                 }
            //             }
            //         },
            //
            //         new EfcoreApp.DAL.Entities.Task
            //         {
            //             Name = "Eating",
            //
            //             Tags = new List<Tag>()
            //             {
            //                 new Tag()
            //                 {
            //                     Name = "Self Care",
            //                     Description = "Putting myself first"
            //                 }
            //             }
            //         }
            //     }
            // };
            //
            // dbContext.Add(demo);
            //
            // Console.WriteLine(await  dbContext.SaveChangesAsync());


            //LazyLading...

            // var amakaTasksTags = await dbContext.Users.OrderBy(u => u.Id).LastOrDefaultAsync();

            //Eager Loading...
            var amakaTasksTags = await dbContext.Users.OrderBy(u => u.Id).Include(i => i.Tasks).ThenInclude(i => i.Tags).LastOrDefaultAsync();




            Console.WriteLine($"{amakaTasksTags?.FirstName}");

            if (amakaTasksTags?.Tasks.Any() == true)
            {
                Console.WriteLine("=========Tasks===============");
                foreach (var task in amakaTasksTags?.Tasks)
                {
                    Console.WriteLine($"{task.Name} {task.IsCompleted}");

                    if (task.Tags.Any())
                    {

                        Console.WriteLine("=====Tags======");
                        foreach (var tag in task.Tags)
                        {
                            Console.WriteLine($"{tag.Name}");
                        }
                    }
                }

            }




        }

    }
}