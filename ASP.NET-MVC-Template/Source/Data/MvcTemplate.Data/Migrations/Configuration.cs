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
                for (int i = 1; i <= 10; i++)
                {
                    var comment = new CommentsForIdeas() { Content = string.Format("Content {0}", i), IP = string.Format("192.168.1.{0}", i), Email = string.Format("s{0}omeemail@abv.bg", i) };
                    context.CommentsForIdeas.Add(comment);
                    commentsList.Add(comment);
                }

                var votesList = new List<VotesForIdeas>();
                for (int i = 1; i <= 100; i++)
                {
                    var vote = new VotesForIdeas() { IP = string.Format("192.168.1.{0}", i), VotePoints = i % 3 };
                    context.VotesForIdeas.Add(vote);
                    votesList.Add(vote);
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

                for (int j = 0; j < 100; j++)
                {
                    idea1.VotesForIdeas.Add(votesList[j]);
                }

                context.Ideas.Add(idea1);
                context.SaveChanges();
                // 2
                var idea2 = new Ideas()
                {
                    Title = "Allow .NET games on Xbox One",
                    Description = "Yesterday was announced that Xbox One will allow indie developer to easily publish games on Xbox One.Lots of indie developers and small game company are using .NET to develop games.Today, we are able to easily target several Windows platforms(Windows Desktop, Windows RT and Windows Phone 8) as well as other platforms thanks to Mono from Xamarin.As we don't know yet the details about this indie developer program for Xbox One, we would love to use .NET on this platform - with everything accessible, from latest 4.5 with async, to unsafe code and native code access through DLLImport (and not only through WinRT components)Please make .NET a compelling game development alternative on Xbox One!",
                    AuthorIP = "192.153.131",
                };

                for (int j = 0; j < 10; j++)
                {
                    idea2.CommentsForIdeas.Add(commentsList[j]);
                }

                for (int j = 0; j < 100; j++)
                {
                    idea2.VotesForIdeas.Add(votesList[j]);
                }

                context.Ideas.Add(idea2);
                context.SaveChanges();

                // 3
                var idea3 = new Ideas()
                {
                    Title = "Support web.config style Transforms on any file in any project type",
                    Description = "Web.config Transforms offer a great way to handle environment-specific settings. XML and other files frequently warrant similar changes when building for development (Debug), SIT, UAT, and production (Release). It is easy to create additional build configurations to support multiple environments via transforms. Unfortunately, not everything can be handled in web.config files many settings need to be changed in xml or other config files.Also,this functionality is needed in other project types - most notably SharePoint 2010 projects.",
                    AuthorIP = "192.153.131",
                };

                for (int j = 0; j < 10; j++)
                {
                    idea3.CommentsForIdeas.Add(commentsList[j]);
                }

                for (int j = 0; j < 100; j++)
                {
                    idea3.VotesForIdeas.Add(votesList[j]);
                }

                context.Ideas.Add(idea3);
                context.SaveChanges();

                var idea4 = new Ideas()
                {
                    Title = "Allow .NET games on Xbox One",
                    Description = "Yesterday was announced that Xbox One will allow indie developer to easily publish games on Xbox One.Lots of indie developers and small game company are using .NET to develop games.Today, we are able to easily target several Windows platforms(Windows Desktop, Windows RT and Windows Phone 8) as well as other platforms thanks to Mono from Xamarin.As we don't know yet the details about this indie developer program for Xbox One, we would love to use .NET on this platform - with everything accessible, from latest 4.5 with async, to unsafe code and native code access through DLLImport (and not only through WinRT components)Please make .NET a compelling game development alternative on Xbox One!",
                    AuthorIP = "192.153.131",
                };

                for (int j = 0; j < 10; j++)
                {
                    idea4.CommentsForIdeas.Add(commentsList[j]);
                }

                for (int j = 0; j < 100; j++)
                {
                    idea3.VotesForIdeas.Add(votesList[j]);
                }

                context.Ideas.Add(idea4);
                context.SaveChanges();
            }
        }
    }
}