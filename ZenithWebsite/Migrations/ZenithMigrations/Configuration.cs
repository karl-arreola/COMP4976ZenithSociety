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
                new Activity {ActivityDescription = "Triathalon", CreationDate = new DateTime(2017, 2, 10)},
                new Activity {ActivityDescription = "Snowboard Tournament", CreationDate = new DateTime(2017, 2, 10)},
                new Activity {ActivityDescription = "Biking Race", CreationDate = new DateTime(2017, 2, 11)},
                new Activity {ActivityDescription = "Basketball Game", CreationDate = new DateTime(2017, 2, 11)},
                new Activity {ActivityDescription = "Soccer Game", CreationDate = new DateTime(2017, 2, 11)}
            };

            return activities.ToArray();
        }

        private Event[] getEvent(ApplicationDbContext context)
        {
            var events = new List<Event>()
            {
                new Event
                { DateFrom = new DateTime(2017, 2, 10, 9, 0, 0),
                    DateTo = new DateTime(2017, 2, 11, 12, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Ski Tournament").ActivityId,
                    CreationDate = new DateTime(2017, 2, 9)
                },
                new Event
                { DateFrom = new DateTime(2017, 2, 10, 14, 0, 0),
                    DateTo = new DateTime(2017, 2, 11, 17, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Triathalon").ActivityId,
                    CreationDate = new DateTime(2017, 2, 9)
                },
                new Event
                { DateFrom = new DateTime(2017, 2, 11, 9, 0, 0),
                    DateTo = new DateTime(2017, 2, 11, 12, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Biking Race").ActivityId,
                    CreationDate = new DateTime(2017, 2, 9)
                },
                new Event
                { DateFrom = new DateTime(2017, 2, 11, 14, 0, 0),
                    DateTo = new DateTime(2017, 2, 11, 17, 0, 0),
                    EventMadeBy = "Jim",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Basketball Game").ActivityId,
                    CreationDate = new DateTime(2017, 2, 10)
                },
                new Event
                { DateFrom = new DateTime(2017, 2, 11, 9, 0, 0),
                    DateTo = new DateTime(2017, 2, 11, 12, 0, 0),
                    EventMadeBy = "Sara",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Soccer Game").ActivityId,
                    CreationDate = new DateTime(2017, 2, 10)
                },
                new Event
                { DateFrom = new DateTime(2017, 2, 12, 14, 0, 0),
                    DateTo = new DateTime(2017, 2, 12, 17, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Triathalon").ActivityId,
                    CreationDate = new DateTime(2017, 2, 11)
                },
                new Event
                { DateFrom = new DateTime(2017, 2, 13, 9, 0, 0),
                    DateTo = new DateTime(2017, 2, 13, 12, 0, 0),
                    EventMadeBy = "Sally",
                    IsActive = false,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Snowboard Tournament").ActivityId,
                    CreationDate = new DateTime(2017, 2, 11)
                },
                new Event
                { DateFrom = new DateTime(2017, 2, 13, 14, 0, 0),
                    DateTo = new DateTime(2017, 2, 13, 17, 0, 0),
                    EventMadeBy = "Jordan",
                    IsActive = false,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Triathalon").ActivityId,
                    CreationDate = new DateTime(2017, 2, 11)
                },
                new Event
                { DateFrom = new DateTime(2017, 2, 14, 9, 0, 0),
                    DateTo = new DateTime(2017, 2, 14, 10, 0, 0),
                    EventMadeBy = "Sally",
                    IsActive = false,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Basketball Game").ActivityId,
                    CreationDate = new DateTime(2017, 2, 12)
                },
                new Event
                { DateFrom = new DateTime(2017, 2, 15, 14, 0, 0),
                    DateTo = new DateTime(2017, 2, 15, 16, 0, 0),
                    EventMadeBy = "Jordan",
                    IsActive = false,
                    ActivityId = context.Activity.FirstOrDefault(c => c.ActivityDescription ==  "Soccer Game").ActivityId,
                    CreationDate = new DateTime(2017, 2, 12)
                }
            };

            return events.ToArray();
        }
    }
}