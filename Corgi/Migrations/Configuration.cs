namespace Corgi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Corgi.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<Corgi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Corgi.Models.ApplicationDbContext context)
        {

            var userRole = "user";
            var admin = "admin";
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(a => a.Name == userRole))
            {
                var role = new IdentityRole { Name = userRole };
                manager.Create(role);
            }
            if (!context.Roles.Any(a => a.Name == admin))
            {
                var role = new IdentityRole { Name = admin };
                manager.Create(role);
            }
            var defaultAdmin = "3sgtejeff@gmail.com";

            if (!context.Users.Any(a => a.UserName == defaultAdmin))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = defaultAdmin };

                userManager.Create(user);
                userManager.AddToRole(user.Id, admin);
            }




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
        }
    }
}
