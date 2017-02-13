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
            context.Event.AddOrUpdate(p => p.CreationDate, getEvent(context));
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
                new Activity {ActivityDescription = "Triathalon", CreationDate = new DateTime(2017, 2, 10)},
                new Activity {ActivityDescription = "Snowboard Tournament", CreationDate = new DateTime(2017, 2, 10)},
                new Activity {ActivityDescription = "Biking Race", CreationDate = new DateTime(2017, 2, 11)},
                new Activity {ActivityDescription = "Basketball Game", CreationDate = new DateTime(2017, 2, 11)},
                new Activity {ActivityDescription = "Soccer Game", CreationDate = new DateTime(2017, 2, 11)},
                new Activity {ActivityDescription = "Golf Tournament", CreationDate = new DateTime(2017, 2, 12)},
                new Activity {ActivityDescription = "Swimming Race", CreationDate = new DateTime(2017, 2, 12)},
                new Activity {ActivityDescription = "Doubles Tennis Game", CreationDate = new DateTime(2017, 2, 12)},
                new Activity {ActivityDescription = "Family Bowling", CreationDate = new DateTime(2017, 2, 13)},
                new Activity {ActivityDescription = "Rock Concert", CreationDate = new DateTime(2017, 2, 13)},
                new Activity {ActivityDescription = "Potluck", CreationDate = new DateTime(2017, 2, 13)}
            };

            return activities.ToArray();
        }

        private Event[] getEvent(ApplicationDbContext context)
        {
            var events = new List<Event>()
            {
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 11, 9, 0, 0),
                    DateTo = new DateTime(2017, 2, 11, 12, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Ski Tournament").ActivityId,
                    CreationDate = new DateTime(2017, 2, 9, 0, 0, 1)
                },
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 12, 14, 0, 0),
                    DateTo = new DateTime(2017, 2, 12, 17, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Triathalon").ActivityId,
                    CreationDate = new DateTime(2017, 2, 9, 0, 0, 2)
                },
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 14, 9, 0, 0),
                    DateTo = new DateTime(2017, 2, 14, 12, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Biking Race").ActivityId,
                    CreationDate = new DateTime(2017, 2, 9, 0, 0, 3)
                },
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 14, 14, 0, 0),
                    DateTo = new DateTime(2017, 2, 14, 17, 0, 0),
                    EventMadeBy = "Jim",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Basketball Game").ActivityId,
                    CreationDate = new DateTime(2017, 2, 10, 0, 0, 4)
                },
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 16, 9, 0, 0),
                    DateTo = new DateTime(2017, 2, 16, 12, 0, 0),
                    EventMadeBy = "Sara",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Soccer Game").ActivityId,
                    CreationDate = new DateTime(2017, 2, 10, 0, 0, 5)
                },
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 16, 14, 0, 0),
                    DateTo = new DateTime(2017, 2, 16, 17, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Triathalon").ActivityId,
                    CreationDate = new DateTime(2017, 2, 11, 0, 0, 6)
                },
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 17, 9, 0, 0),
                    DateTo = new DateTime(2017, 2, 17, 12, 0, 0),
                    EventMadeBy = "Sally",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Snowboard Tournament").ActivityId,
                    CreationDate = new DateTime(2017, 2, 11, 0, 0, 7)
                },
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 13, 14, 0, 0),
                    DateTo = new DateTime(2017, 2, 13, 17, 0, 0),
                    EventMadeBy = "Jordan",
                    IsActive = false,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Triathalon").ActivityId,
                    CreationDate = new DateTime(2017, 2, 11, 0, 0, 8)
                },
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 19, 9, 0, 0),
                    DateTo = new DateTime(2017, 2, 19, 10, 0, 0),
                    EventMadeBy = "Sally",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Basketball Game").ActivityId,
                    CreationDate = new DateTime(2017, 2, 12, 0, 0, 9)
                },
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 15, 14, 0, 0),
                    DateTo = new DateTime(2017, 2, 15, 16, 0, 0),
                    EventMadeBy = "Jordan",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Soccer Game").ActivityId,
                    CreationDate = new DateTime(2017, 2, 12, 0, 0, 10)
                },
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 20, 17, 0, 0),
                    DateTo = new DateTime(2017, 2, 20, 20, 0, 0),
                    EventMadeBy = "Jen",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Potluck").ActivityId,
                    CreationDate = new DateTime(2017, 2, 12, 0, 0, 11)
                },
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 21, 19, 0, 0),
                    DateTo = new DateTime(2017, 2, 21, 22, 0, 0),
                    EventMadeBy = "Jen",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Rock Concert").ActivityId,
                    CreationDate = new DateTime(2017, 2, 12, 0, 0, 12)
                },
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 18, 13, 0, 0),
                    DateTo = new DateTime(2017, 2, 18, 17, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Golf Tournament").ActivityId,
                    CreationDate = new DateTime(2017, 2, 12, 0, 0, 13)
                },
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 15, 9, 0, 0),
                    DateTo = new DateTime(2017, 2, 15, 10, 0, 0),
                    EventMadeBy = "a",
                    IsActive = false,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Swimming Race").ActivityId,
                    CreationDate = new DateTime(2017, 2, 12, 0, 0, 14)
                },
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 16, 12, 0, 0),
                    DateTo = new DateTime(2017, 2, 16, 13, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Doubles Tennis Game").ActivityId,
                    CreationDate = new DateTime(2017, 2, 12, 0, 0, 15)
                },
                new Event
                {
                    DateFrom = new DateTime(2017, 2, 15, 16, 0, 0),
                    DateTo = new DateTime(2017, 2, 15, 18, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Family Bowling").ActivityId,
                    CreationDate = new DateTime(2017, 2, 12, 0, 0, 16)
                }
            };

            return events.ToArray();
        }
    }
}