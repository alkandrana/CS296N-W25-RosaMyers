using OnTolkien.Models;
using Microsoft.AspNetCore.Identity;
namespace OnTolkien.Data;

public class SeedData
{
    public static void Seed(AppDbContext ctx, IServiceProvider provider)
    {
        if (!ctx.Stories.Any())
        {
            var userManager = provider.GetRequiredService<UserManager<AppUser>>();
            // user1
            const string SECRET_PASSWORD1 = "alk0nd1r";
            AppUser contributor1 = new AppUser { UserName = "Rachel McKenzie" };
            var result1 = userManager.CreateAsync(contributor1, SECRET_PASSWORD1);
            // user2
            const string SECRET_PASSWORD2 = "D1nlask1th";
            AppUser contributor2 = new AppUser { UserName = "Elithan" };
            var result2 = userManager.CreateAsync(contributor2, SECRET_PASSWORD2);
            // user3
            const string SECRET_PASSWORD3 = "Sn0wd0n";
            AppUser contributor3 = new AppUser { UserName = "James McKenzie" };
            var result3 = userManager.CreateAsync(contributor3, SECRET_PASSWORD3);
            
            ctx.Users.Add(contributor1);
            ctx.Users.Add(contributor2);
            ctx.Users.Add(contributor3);
            ctx.SaveChanges();

            Story story1 = new Story
            {
                StoryText =
                    "I've been reading these books since I was a little girl, and they are probably the biggest influence on my own epic fantasy!",
                Title = "A Long Acquaintance",
                Topic = "Reading",
                Contributor = contributor1,
                EntryDate = DateTime.Parse("11/25/2024"),
                StoryYear = 2013
            };

            Story story2 = new Story
            {
                Contributor = contributor2,
                EntryDate = DateTime.Parse("11/25/1890"),
                StoryText = "I used to live in Middle-Earth.",
                StoryYear = 2013,
                Title = "Nostalgia",
                Topic = "Memories"
            };

            Story story3 = new Story
            {
                Contributor = contributor3,
                EntryDate = DateTime.Now,
                StoryText = "My sister and I used to act out scenes from the book as a game.",
                StoryYear = 1994,
                Title = "Playtime",
                Topic = "Memories"
            };
            
            ctx.Stories.Add(story1);
            ctx.Stories.Add(story2);
            ctx.Stories.Add(story3);
            ctx.SaveChanges();
        }
    }
}