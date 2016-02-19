namespace MvcTemplate.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using MvcTemplate.Common;
    using MvcTemplate.Data.Models;
    using System.Collections.Generic;
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }

            if (context.Users.Count() < 2)
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "MyRegisteredUsers" };
                roleManager.Create(role);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = "user1@site.com", Email = "user1@site.com" };
                userManager.Create(user, "user1");
                context.Users.Add(user);
                context.SaveChanges();
            }

            if (context.Ideas.Any())
            {
                var commentsList = new List<CommentsForIdeas>();
                for (int i = 1; i <= 20; i++)
                {
                    var comment = new CommentsForIdeas() { Content = string.Format("Content {0}", i), IP = string.Format("192.168.1.{0}", i), Email = string.Format("s{0}omeemail@abv.bg", i) };
                    context.CommentsForIdeas.Add(comment);
                    commentsList.Add(comment);
                }

                var idea1 = new Ideas()
                {
                    Title = "XNA 5",
                    Description = "Please continue to work on XNA. It's a great way for indie game developers like myself to make games and give them to the world. XNA gave us the ability to put our games, easily, on the most popular platforms, and to just dump XNA would be therefor heartbreaking... I implore you to keep working on XNA so we C# developers can still make amazing games!",
                    AuthorIP = "192.153.1.1",
                };

                for (int j = 0; j < 10; j++)
                {
                    idea1.CommentsForIdeas.Add(commentsList[j]);
                }

                context.Ideas.Add(idea1);
                context.SaveChanges();
        }
        }
    }
}