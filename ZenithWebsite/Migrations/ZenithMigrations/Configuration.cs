namespace ZenithWebsite.Migrations.ZenithMigrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib.Models;

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
                new Event { DateFrom = new DateTime(2017, 2, 11, 9, 0, 0), DateTo = new DateTime(2017, 2, 11, 12, 0, 0), EventMadeBy = "Joe",
                    IsActive = false, CreationDate = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Ski Tournament").CreationDate},
                new Event { DateFrom = new DateTime(2017, 2, 11, 14, 0, 0), DateTo = new DateTime(2017, 2, 11, 17, 0, 0), EventMadeBy = "Sam",
                    IsActive = false, CreationDate = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Triathalon").CreationDate}
            };

            return events.ToArray();
        }
    }
}
