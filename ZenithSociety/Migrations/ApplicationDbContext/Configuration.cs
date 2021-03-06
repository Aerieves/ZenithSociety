namespace ZenithSociety.Migrations.ApplicationDbContext
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithSociety.Models.ApplicationDbContext>
    {
        public string dummyId;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationDbContext";
        }

        protected override void Seed(ZenithSociety.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };

                roleManager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Member" };

                roleManager.Create(role);
            }

            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("P@$$w0rd");

            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            if (!context.Users.Any(u => u.UserName == "a"))
            {
                var user = new ApplicationUser { UserName = "a", Email = "a@a.a", PasswordHash = password };
                manager.Create(user);
                dummyId = user.Id;
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "m"))
            {
                var user1 = new ApplicationUser { UserName = "m", Email = "m@m.c", PasswordHash = password };
                manager.Create(user1);
                manager.AddToRole(user1.Id, "Member");
            }

            context.Activities.AddOrUpdate(a => a.ActivityId, getActivities().ToArray());
            context.SaveChanges();

            context.Events.AddOrUpdate(e => e.EventId, getEvents(dummyId, context).ToArray());
            context.SaveChanges();
        }

        private List<Activity> getActivities()
        {
            List<Activity> activities = new List<Activity>();
            activities.Add(new Activity
            {
                ActivityDescription = "Senior's Golf Tournament",
                CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
            });
            activities.Add(new Activity
            {
                ActivityDescription = "Leadership General Assembly Meeting",
                CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
            });
            activities.Add(new Activity
            {
                ActivityDescription = "Youth Bowling Tournament",
                CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
            });
            activities.Add(new Activity
            {
                ActivityDescription = "Young ladies cooking lessons",
                CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
            });
            activities.Add(new Activity
            {
                ActivityDescription = "Youth craft lessons",
                CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
            });
            activities.Add(new Activity
            {
                ActivityDescription = "Youth choir practice",
                CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
            });
            activities.Add(new Activity
            {
                ActivityDescription = "Lunch",
                CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
            });
            activities.Add(new Activity
            {
                ActivityDescription = "Pancake Breakfast",
                CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
            });
            activities.Add(new Activity
            {
                ActivityDescription = "Swimming Lessons for the youth",
                CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
            });
            activities.Add(new Activity
            {
                ActivityDescription = "Swimming Exercise for parents",
                CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
            });
            activities.Add(new Activity
            {
                ActivityDescription = "Bingo Tournament",
                CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
            });
            activities.Add(new Activity
            {
                ActivityDescription = "BBQ Lunch",
                CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
            });
            activities.Add(new Activity
            {
                ActivityDescription = "Garage Sale",
                CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
            });
            return activities;
        }

        public static List<Event> getEvents(String dummyId, ApplicationDbContext db)
        {
            List<Event> events = new List<Event>()
            {
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/17 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/17 10:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Senior's Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/18 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/18 10:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Leadership General Assembly Meeting"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/20 5:30 pm"),
                    EndDate = Convert.ToDateTime("2016/10/20 7:15 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/20 7:00 pm"),
                    EndDate = Convert.ToDateTime("2016/10/20 8:00 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/21 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/21 10:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/21 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/21 12:00 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/21 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/10/21 1:30 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/22 7:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/22 8:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/22 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/22 10:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/22 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/22 10:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/22 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/22 12:00 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Bingo Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/22 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/10/22 1:00 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/22 1:00 pm"),
                    EndDate = Convert.ToDateTime("2016/10/22 6:00 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/23 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/23 10:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Senior's Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/24 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/24 10:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Leadership General Assembly Meeting"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/25 5:30 pm"),
                    EndDate = Convert.ToDateTime("2016/10/25 7:15 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/25 7:00 pm"),
                    EndDate = Convert.ToDateTime("2016/10/25 8:00 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/26 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/26 10:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/26 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/26 12:00 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/26 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/10/26 1:30 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/27 7:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/27 8:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/27 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/27 10:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/28 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/28 10:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/28 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/28 12:00 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Bingo Tournament"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/28 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/10/28 1:00 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/29 1:00 pm"),
                    EndDate = Convert.ToDateTime("2016/10/29 6:00 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/30 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/30 10:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Senior's Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/31 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/31 10:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Leadership General Assembly Meeting"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/01 5:30 pm"),
                    EndDate = Convert.ToDateTime("2016/11/01 7:15 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/01 7:00 pm"),
                    EndDate = Convert.ToDateTime("2016/11/01 8:00 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/02 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/02 10:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/02 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/02 12:00 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/02 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/11/02 1:30 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/03 7:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/03 8:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/03 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/03 10:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/04 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/04 10:30 am"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/04 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/04 12:00 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Bingo Tournament"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/04 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/11/04 1:00 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
                new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/05 1:00 pm"),
                    EndDate = Convert.ToDateTime("2016/11/05 6:00 pm"),
                    Id = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/10/19"),
                    IsActive = true
                },
            };
            return events;
        }
    }
}
