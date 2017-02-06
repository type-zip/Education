using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCMovie.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

                if(context.Movie.Any())
                {
                    return;
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("2016-01-11"),
                        Genre = "Romantic Comedy",
                        Price = 250.0M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("2001-01-12"),
                        Genre = "Fiction",
                        Price = 300.0M,
                        Rating = "D"
                    },

                    new Movie
                    {
                        Title = "Wind That Shakes A Barley",
                        ReleaseDate = DateTime.Parse("1986-02-03"),
                        Genre = "Documentary",
                        Price = 450.0M,
                        Rating = "C"
                    },

                    new Movie
                    {
                        Title = "My Little Armalie",
                        ReleaseDate = DateTime.Parse("1950-01-01"),
                        Genre = "Jam",
                        Price = 750000.0M,
                        Rating = "A"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
