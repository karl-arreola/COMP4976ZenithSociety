namespace ZenithWebsite.Migrations.ZenithMigrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithDataLib.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ZenithMigrations";
        }

        protected override void Seed(ZenithDataLib.Models.ApplicationDbContext context)
        {
            context.Activity.AddOrUpdate(c => c.ActivityDescription, getActivity());
            context.SaveChanges();
            context.Event.AddOrUpdate(p => p.EventId, getEvent(context));
            context.SaveChanges();

            createRoles(context);
            createUsers(context);
        }

        private void createRoles(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("Member"))
                roleManager.Create(new IdentityRole("Member"));
        }

        private void createUsers(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Add a user with email of a@a.a username a then add to admin role
            if (userManager.FindByEmail("a@a.a") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "a",
                    Email = "a@a.a",
                    FirstName = "Admin",
                    LastName = "Admin"
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Admin");
            }

            // Add a user with email of m@m.m username m then add to member role
            if (userManager.FindByEmail("m@m.m") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "m",
                    Email = "m@m.m",
                    FirstName = "Member",
                    LastName = "Member"
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Member");
            }
        }

        private Activity[] getActivity()
        {
            var activities = new List<Activity>
            {
                new Activity {ActivityDescription = "Ski Tournament", CreationDate = new DateTime(2017, 2, 9)},
                new Activity {ActivityDescription = "Triathalon", CreationDate = new DateTime(2017, 2, 10)}
            };

            return activities.ToArray();
        }

        private Event[] getEvent(ApplicationDbContext context)
        {
            var events = new List<Event>()
            {
                new Event
                { DateFrom = new DateTime(2017, 2, 11, 9, 0, 0),
                    DateTo = new DateTime(2017, 2, 11, 12, 0, 0),
                    EventMadeBy = "Joe",
                    IsActive = false,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Ski Tournament").ActivityId,
                    CreationDate = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Ski Tournament").CreationDate
                },
                new Event
                { DateFrom = new DateTime(2017, 2, 11, 14, 0, 0),
                    DateTo = new DateTime(2017, 2, 11, 17, 0, 0),
                    EventMadeBy = "Sam",
                    IsActive = false,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Triathalon").ActivityId,
                    CreationDate = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Triathalon").CreationDate
                }
            };

            return events.ToArray();
        }
    }
}