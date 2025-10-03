using Macaroon_bot.Model;
using NuGet.Packaging;

namespace MacaroonBot.Model
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDBContext context)
        {
            // ===== 2+ =====
            if (!context.Activities.Any(a => a.Name == "2+"))
            {
                var activity2 = new Activity
                {
                    Name = "2+",
                    Duration = TimeSpan.FromHours(1),
                    Price = 150000,
                    IsSubscription = false,
                };

                var group2_10 = new Group
                {
                    Name = "Группа 2+ 10:00",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                group2_10.Schedules.AddRange(new[]
                {
                    new Schedule { DayOfWeek = DayOfWeek.Tuesday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(11,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Thursday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(11,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Saturday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(11,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow }
                });

                var group2_11 = new Group
                {
                    Name = "Группа 2+ 11:00",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                group2_11.Schedules.AddRange(new[]
                {
                    new Schedule { DayOfWeek = DayOfWeek.Tuesday, StartTime = new TimeSpan(11,0,0), EndTime = new TimeSpan(12,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Thursday, StartTime = new TimeSpan(11,0,0), EndTime = new TimeSpan(12,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Saturday, StartTime = new TimeSpan(11,0,0), EndTime = new TimeSpan(12,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow }
                });

                activity2.Groups.Add(group2_10);
                activity2.Groups.Add(group2_11);
                context.Activities.Add(activity2);
            }

            // ===== 3+ =====
            if (!context.Activities.Any(a => a.Name == "3+"))
            {
                var activity3 = new Activity
                {
                    Name = "3+",
                    Duration = TimeSpan.FromHours(1),
                    Price = 150000,
                    IsSubscription = false,
                };

                var group3_10 = new Group
                {
                    Name = "Группа 3+ 10:00",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                group3_10.Schedules.AddRange(new[]
                {
                    new Schedule { DayOfWeek = DayOfWeek.Tuesday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(11,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Thursday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(11,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Saturday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(11,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow }
                });

                var group3_11 = new Group
                {
                    Name = "Группа 3+ 11:00",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                group3_11.Schedules.AddRange(new[]
                {
                    new Schedule { DayOfWeek = DayOfWeek.Tuesday, StartTime = new TimeSpan(11,0,0), EndTime = new TimeSpan(12,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Thursday, StartTime = new TimeSpan(11,0,0), EndTime = new TimeSpan(12,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Saturday, StartTime = new TimeSpan(11,0,0), EndTime = new TimeSpan(12,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow }
                });

                activity3.Groups.Add(group3_10);
                activity3.Groups.Add(group3_11);
                context.Activities.Add(activity3);
            }

            // ===== 4+ =====
            if (!context.Activities.Any(a => a.Name == "4+"))
            {
                var activity4 = new Activity
                {
                    Name = "4+",
                    Duration = TimeSpan.FromHours(3),
                    Price = 1500000,
                    IsSubscription = true,
                };

                var group4 = new Group
                {
                    Name = "Группа 4+ 10:00–13:00",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                group4.Schedules.AddRange(new[]
                {
                    new Schedule { DayOfWeek = DayOfWeek.Tuesday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(13,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Thursday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(13,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Saturday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(13,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow }
                });

                activity4.Groups.Add(group4);
                context.Activities.Add(activity4);
            }

            // ===== 5+ =====
            if (!context.Activities.Any(a => a.Name == "5+"))
            {
                var activity5 = new Activity
                {
                    Name = "5+",
                    Duration = TimeSpan.FromHours(3),
                    Price = 1500000,
                    IsSubscription = true,
                };

                var group5_morning = new Group
                {
                    Name = "Группа 5+ 10:00–13:00",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                group5_morning.Schedules.AddRange(new[]
                {
                    new Schedule { DayOfWeek = DayOfWeek.Monday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(13,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(13,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Friday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(13,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow }
                });

                var group5_day = new Group
                {
                    Name = "Группа 5+ 14:00–17:00",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                group5_day.Schedules.AddRange(new[]
                {
                    new Schedule { DayOfWeek = DayOfWeek.Monday, StartTime = new TimeSpan(14,0,0), EndTime = new TimeSpan(17,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeSpan(14,0,0), EndTime = new TimeSpan(17,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Friday, StartTime = new TimeSpan(14,0,0), EndTime = new TimeSpan(17,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow }
                });

                activity5.Groups.Add(group5_morning);
                activity5.Groups.Add(group5_day);
                context.Activities.Add(activity5);
            }

            // ===== 6+ =====
            if (!context.Activities.Any(a => a.Name == "6+"))
            {
                var activity6 = new Activity
                {
                    Name = "6+",
                    Duration = TimeSpan.FromHours(3),
                    Price = 1600000,
                    IsSubscription = true,
                };

                var group6_morning = new Group
                {
                    Name = "Группа 6+ 10:00–13:00",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                group6_morning.Schedules.AddRange(new[]
                {
                    new Schedule { DayOfWeek = DayOfWeek.Monday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(13,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(13,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Friday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(13,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow }
                });

                var group6_day = new Group
                {
                    Name = "Группа 6+ 14:00–17:00",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                group6_day.Schedules.AddRange(new[]
                {
                    new Schedule { DayOfWeek = DayOfWeek.Monday, StartTime = new TimeSpan(14,0,0), EndTime = new TimeSpan(17,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeSpan(14,0,0), EndTime = new TimeSpan(17,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Friday, StartTime = new TimeSpan(14,0,0), EndTime = new TimeSpan(17,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow }
                });

                activity6.Groups.Add(group6_morning);
                activity6.Groups.Add(group6_day);
                context.Activities.Add(activity6);
            }

            // ===== Танцы =====
            if (!context.Activities.Any(a => a.Name == "Танцы"))
            {
                var dances = new Activity
                {
                    Name = "Танцы",
                    Duration = new TimeSpan(1, 30, 0),
                    Price = 400000,
                    IsSubscription = true
                };

                var groupDances = new Group
                {
                    Name = "Группа Танцы 13:00–14:30",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                groupDances.Schedules.AddRange(new[]
                {
                    new Schedule { DayOfWeek = DayOfWeek.Monday, StartTime = new TimeSpan(13,0,0), EndTime = new TimeSpan(14,30,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeSpan(13,0,0), EndTime = new TimeSpan(14,30,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow }
                });

                dances.Groups.Add(groupDances);
                context.Activities.Add(dances);
            }

            // ===== Английский =====
            if (!context.Activities.Any(a => a.Name == "Английский язык"))
            {
                var eng = new Activity
                {
                    Name = "Английский язык",
                    Duration = TimeSpan.FromHours(1),
                    Price = 500000,
                    IsSubscription = true
                };

                var groupEng = new Group
                {
                    Name = "Группа Английский",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                groupEng.Schedules.AddRange(new[]
                {
                    new Schedule { DayOfWeek = DayOfWeek.Monday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(11,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(11,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow },
                    new Schedule { DayOfWeek = DayOfWeek.Friday, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(11,0,0), CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow }
                });

                eng.Groups.Add(groupEng);
                context.Activities.Add(eng);
            }

            // ===== Мастер класс =====
            if (!context.Activities.Any(a => a.Name == "Мастер-класс путешествия по свету"))
            {
                var master = new Activity
                {
                    Name = "Мастер-класс путешествия по свету",
                    Duration = new TimeSpan(1, 30, 0),
                    Price = 150000,
                    IsSubscription = false
                };

                var groupMaster = new Group
                {
                    Name = "Группа Мастер-класс",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                groupMaster.Schedules.Add(new Schedule
                {
                    DayOfWeek = DayOfWeek.Saturday,
                    StartTime = new TimeSpan(12, 0, 0),
                    EndTime = new TimeSpan(13, 30, 0),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });

                master.Groups.Add(groupMaster);
                context.Activities.Add(master);
            }

            // ===== Логопедические =====
            if (!context.Activities.Any(a => a.Name == "Логопедические занятия"))
            {
                context.Activities.Add(new Activity
                {
                    Name = "Логопедические занятия",
                    Duration = new TimeSpan(0, 45, 0),
                    Price = 200000,
                    IsSubscription = false
                });
            }

            // ===== Консультация логопеда =====
            if (!context.Activities.Any(a => a.Name == "Консультация логопеда"))
            {
                context.Activities.Add(new Activity
                {
                    Name = "Консультация логопеда",
                    Duration = new TimeSpan(0, 45, 0),
                    Price = 200000,
                    IsSubscription = false
                });
            }

            context.SaveChanges();
        }
    }
}
