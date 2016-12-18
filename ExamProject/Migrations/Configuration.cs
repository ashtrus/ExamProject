using System.Diagnostics;

namespace ExamProject.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;



    internal sealed class Configuration : DbMigrationsConfiguration<ExamProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ExamProject.Models.ApplicationDbContext context)
        {
            // https://code.msdn.microsoft.com/ASPNET-MVC-5-Security-And-44cbdb97
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //userManager.Create

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                if (!userManager.Users.Any(x => x.UserName == "admin@kea.dk"))
                {
                    var user = new ApplicationUser { UserName = "admin@kea.dk", Email = "admin@kea.dk" };

                    string userPWD = "Passw0rd!";

                    var chkUser = userManager.Create(user, userPWD);

                    //Add default User to Role Admin   
                    if (chkUser.Succeeded)
                    {
                        var result1 = userManager.AddToRole(user.Id, "Admin");
                    }
                }

            }


            // creating Creating Employee role    
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }

            // 
            //if (!userManager.Users.Any(x => x.UserName == "admin@kea.dk"))
            //{
            //    var user = new ApplicationUser { UserName = "admin@kea.dk", Email = "admin@kea.dk" };

            //    string userPWD = "123321";

            //    var chkUser = userManager.Create(user, userPWD);

            //    //Add default User to Role Admin   
            //    if (chkUser.Succeeded)
            //    {
            //        var result1 = userManager.AddToRole(user.Id, "Admin");
            //    }
            //}

            //var adminUser = userManager.Users.First(x => x.UserName == "admin@kea.dk");
            //Debug.WriteLine($"{adminUser.UserName} exists");
        }
       
    }
}

