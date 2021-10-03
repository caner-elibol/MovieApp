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

            var genres = new List<Genre>
            {
             new Genre{Name="Romantik",Movies=
                 new List<Movie>
                 {
                     new Movie
                     {
                         Title = "Romantik Bir Film",
                         Description = "Acıklama",
                         ImageUrl = "1.jpg"
                     },
                     new Movie
                     {
                         Title = "Romantik Bir Film 2",
                         Description = "Acıklama",
                         ImageUrl = "2.jpg",
                     },
                 }

            },
             new Genre{Name="Dram",Movies=
             new List<Movie>
                 {
                     new Movie
                     {
                         Title = "Dram Akıyor",
                         Description = "Acıklama",
                         ImageUrl = "1.jpg"
                     },
                     new Movie
                     {
                         Title = "Dram Akıyor 2",
                         Description = "Acıklama",
                         ImageUrl = "2.jpg",
                     },
                 }},
             new Genre{Name="Korku/Gerilim",Movies=
             new List<Movie>
                 {
                     new Movie
                     {
                         Title = "Dabbe",
                         Description = "Acıklama",
                         ImageUrl = "1.jpg"
                     },
                     new Movie
                     {
                         Title = "Dabbe 2",
                         Description = "Acıklama",
                         ImageUrl = "2.jpg",
                     },
                 }},
             new Genre{Name="Aksiyon"},
             new Genre{Name="Komedi"}
            };
            var movies = new List<Movie>() {
                new Movie
                    {
                        Title = "Recep İvedik",
                        Description = "Acıklama",
                        ImageUrl = "1.jpg",
                        Genres=new List<Genre>() {genres[0],genres[1], genres[2], genres[4] }
                    },
                    new Movie
                    {
                        Title = "Recep İvedik",
                        Description = "Acıklama",
                        ImageUrl = "2.jpg",
                        Genres=new List<Genre>() {genres[4],genres[1]}
                    },
                    new Movie
                    {
                        Title = "Recep İvedik",
                        Description = "Acıklama",
                        ImageUrl = "3.jpg",
                        Genres=new List<Genre>() {genres[2],genres[3] }
                    },
                    new Movie
                    {
                        Title = "Recep İvedik",
                        Description = "Acıklama",
                        ImageUrl = "1.jpg",
                        Genres=new List<Genre>() {genres[4],genres[2]}
                    },
                    new Movie
                    {
                        Title = "Recep İvedik",
                        Description = "Acıklama",
                        ImageUrl = "2.jpg",
                        Genres=new List<Genre>() {genres[4],genres[1]}
                    },
                    new Movie
                    {
                        Title = "Recep İvedik",
                        Description = "Acıklama",
                        ImageUrl = "3.jpg",
                        Genres=new List<Genre>() {genres[4],genres[3]}
                    }
        };
            var users = new List<User> {
                new User(){Username="user1",Email="user1@fmail.com",Password="1234",ImageUrl="person1.jpg"},
                new User(){Username="user2",Email="user2@fmail.com",Password="1234",ImageUrl="person2.jpg"},
                new User(){Username="user3",Email="user3@fmail.com",Password="1234",ImageUrl="person3.jpg"},
                new User(){Username="user4",Email="user4@fmail.com",Password="1234",ImageUrl="person4.jpg"},
                new User(){Username="user5",Email="user5@fmail.com",Password="1234",ImageUrl="person5.jpg"}
            };
            var persons = new List<Person> {
                
                new Person()
                {
                    Name="Personel 1",
                    Biography="Oynar",
                    PlaceOfBirth="Ankara",
                    HomePage="hp1",
                    Imdb="imdb.com/personal1",
                    User=users[0]
                } ,
               new Person()
                {
                    Name="Personel 2",
                    Biography="Oynamaz",
                    PlaceOfBirth="İstanbul",
                    HomePage="hp2",
                    Imdb="imdb.com/personal2",
                    User=users[1]
                } 
            };
            var crews = new List<Crew> {

                new Crew()
                {
                    Movie=movies[1],
                    Person=persons[1],
                    Job="Yönetmen"
                } ,
               new Crew()
                {
                   Movie=movies[0],
                   Person=persons[1],
                   Job="Yönetmen Yrd."
                } ,
            };
            var casts = new List<Cast> {

                new Cast()
                {
                    Movie=movies[1],
                    Person=persons[1],
                    CastName="ad1",
                    Character="Bahçıvan"
                } ,
               new Cast()
                {
                   Movie=movies[0],
                   Person=persons[1],
                   CastName="ad2",
                   Character="Uşak"
                } 
            };




            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Genres.Count() == 0)
                {
                    context.AddRange(genres);
                }
                if (context.Movies.Count() == 0)
                {
                    context.Movies.AddRange(movies);
                }
                if (context.Users.Count() == 0)
                {
                    context.Users.AddRange(users);
                }
                if (context.Persons.Count() == 0)
                {
                    context.Persons.AddRange(persons);
                }
                if (context.Casts.Count() == 0)
                {
                    context.Casts.AddRange(casts);
                }
                if (context.Crews.Count() == 0)
                {
                    context.Crews.AddRange(crews);
                }
                

                context.SaveChanges();
            }

        }
    }
}
