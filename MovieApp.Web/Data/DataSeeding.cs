using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Data
{
    public class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();

            context.Database.Migrate();

            if (context.Database.GetPendingMigrations().Count()==0)
            {
                if (context.Movies.Count()==0)
                {
                    context.Movies.AddRange(
                    new Movie
                    {
                        MovieId = 1,
                        Title = "Recep İvedik",
                        Description = "Acıklama",
                        Director = "Togan Gökbakar",
                        ImageUrl = "1.jpg",
                        GenreId = 3
                    },
                    new Movie
                    {
                        MovieId = 2,
                        Title = "Recep İvedik",
                        Description = "Acıklama",
                        Director = "Togan Gökbakar",
                        ImageUrl = "1.jpg",
                        GenreId = 1
                    },
                    new Movie
                    {
                        MovieId = 3,
                        Title = "Recep İvedik",
                        Description = "Acıklama",
                        Director = "Togan Gökbakar",
                        ImageUrl = "1.jpg",
                        GenreId = 2
                    },
                    new Movie
                    {
                        MovieId = 4,
                        Title = "Recep İvedik",
                        Description = "Acıklama",
                        Director = "Togan Gökbakar",
                        ImageUrl = "1.jpg",
                        GenreId = 1
                    },
                    new Movie
                    {
                        MovieId = 5,
                        Title = "Recep İvedik",
                        Description = "Acıklama",
                        Director = "Togan Gökbakar",
                        ImageUrl = "1.jpg",
                        GenreId = 3
                    },
                    new Movie
                    {
                        MovieId = 6,
                        Title = "Recep İvedik",
                        Description = "Acıklama",
                        Director = "Togan Gökbakar",
                        ImageUrl = "1.jpg",
                        GenreId = 2
                    });
                }
                if (context.Genres.Count()==0)
                {
                    context.AddRange(
                        new List<Genre>
                        {
                            new Genre{GenreId=1,Name="Romantik"},
                            new Genre{GenreId=2,Name="Dram"},
                            new Genre{GenreId=3,Name="Korku/Gerilim"},
                            new Genre{GenreId=4,Name="Aksiyon"},
                            new Genre{GenreId=5,Name="Komedi"}
                        }
                        );
                }
                context.SaveChanges();
                
            }
            
        }
    }
}
