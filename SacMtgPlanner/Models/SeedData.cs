using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace SacMtgPlanner.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SacMtgPlannerContext(
                serviceProvider.GetRequiredService<DbContextOptions<SacMtgPlannerContext>>()))
            {
                // Look for any Meetings.
                if (context.Meeting.Any())
                {
                    return;   // DB has been seeded
                }

                context.Meeting.AddRange(
                     new Meeting
                     {
                         Subject = "Faith",
                         ReleaseDate = DateTime.Parse("04-15-2018"),
                         Conducting = "Bishop Speaker",
                         OpenPrayer = "George Sampson",
                         ClosePrayer = "Val Thompson",
                         YouthSpeaker = "Tim Jenkins",
                         FirstSpeaker = "Jan Davis",
                         SecondSpeaker = "Tom Davis",
                         OpenHymn = "The Spirit of God (#2)",
                         SacHymn = "How Great Thou Art (#86)",
                         CloseHymn = "Faith of Our Fathers (#84)"
                     },

                     new Meeting
                     {
                         Subject = "Missionary Work",
                         ReleaseDate = DateTime.Parse("04-22-2018"),
                         Conducting = "Bro. Basha",
                         OpenPrayer = "Kim Kinkle",
                         ClosePrayer = "Chris Kinkle",
                         YouthSpeaker = "Matt Harris",
                         FirstSpeaker = "Brian Allen",
                         SecondSpeaker = "Lynn Allen",
                         OpenHymn = "Call to Serve (#249)",
                         SacHymn = "Jesus, Once of Humble Birth (#196)",
                         CloseHymn = "Press Forward, Saints (#81)"
                     },
                     
                     new Meeting
                     {
                         Subject = "Scriptures",
                         ReleaseDate = DateTime.Parse("04-29-2018"),
                         Conducting = "Bro. Vance",
                         OpenPrayer = "Randy Baker",
                         ClosePrayer = "Patsy Baker",
                         YouthSpeaker = "Kara Cetin",
                         FirstSpeaker = "Jay Crockett",
                         SecondSpeaker = "Rhonda Crockett",
                         OpenHymn = "Rock of Ages (#111)",
                         SacHymn = "Savoir, Redeemer of My Soul (#112)",
                         CloseHymn = "I Believe in Christ (#134)"
                     },

                     new Meeting
                     {
                         Subject = "Ministering",
                         ReleaseDate = DateTime.Parse("05-06-2018"),
                         Conducting = "Bishop Speaker",
                         OpenPrayer = "Ben Goff",
                         ClosePrayer = "Lisa Goff",
                         YouthSpeaker = "Josh Graham",
                         FirstSpeaker = "Doug Greer",
                         SecondSpeaker = "Rachael Greer",
                         OpenHymn = "Let the Holy Spirit Guide (#143)",
                         SacHymn = "Be Thou Humble (#130)",
                         CloseHymn = "Did You Think to Pray (#140)"
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
