using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;

        static MovieRepository()
        {
            _movies = new List<Movie>()
            {
                new Movie
                {
                    MovieId=1,
                    Title="Esaretin Bedeli",
                    Description="Kaçma konusu",
                    Director="Kimdi Bilmiyorum",
                    Actors=new string[]{"Brad Pitt","Angelina Jolie"},
                    ImageUrl="1.jpg",
                    GenreId=3
                },
                new Movie
                {
                    MovieId=2,
                    Title="Wanted",
                    Description="Suç",
                    Director="Kimdi Bilmiyorum",
                    Actors=new string[]{"Oscar Wilde","Angelina Jolie"},
                    ImageUrl="2.jpg",
                    GenreId=1
                },
                new Movie
                {
                    MovieId=3,
                    Title="Recep İvedik",
                    Description="Komedi",
                    Director="Togan Gökbakar",
                    Actors=new string[]{"Şahan Gökbakar","Cem Gecici"},
                    ImageUrl="3.jpg",
                    GenreId=1
                },
                new Movie
                {
                    MovieId=4,
                    Title="Esaretin Bedeli",
                    Description="Kaçma konusu",
                    Director="Kimdi Bilmiyorum",
                    Actors=new string[]{"Brad Pitt","Angelina Jolie"},
                    ImageUrl="1.jpg",
                    GenreId=2
                },
                new Movie
                {
                    MovieId=5,
                    Title="Wanted",
                    Description="Suç",
                    Director="Kimdi Bilmiyorum",
                    Actors=new string[]{"Oscar Wilde","Angelina Jolie"},
                    ImageUrl="2.jpg",
                    GenreId=3
                },
                new Movie
                {
                    MovieId=6,
                    Title="Recep İvedik",
                    Description="Komedi",
                    Director="Togan Gökbakar",
                    Actors=new string[]{"Şahan Gökbakar","Cem Gecici"},
                    ImageUrl="3.jpg",
                    GenreId=2
                }
            };
        }
        public static List<Movie> Movies
        {
            get
            {
                return _movies;
            }
        }

        public static void Delete(int movieId)
        {
            var movie = GetById(movieId);
            if (movie != null)
            {
                _movies.Remove(movie);
            }
        }

        public static void Add(Movie movie)
        {
            movie.MovieId = _movies.Count() + 1;
            _movies.Add(movie);
        }
        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.MovieId == id);
        }
        public static void Edit(Movie m)
        {
            foreach (var movie in _movies)
            {
                if (movie.MovieId==m.MovieId)
                {
                    movie.Title = m.Title;
                    movie.Description = m.Description;
                    movie.Director = m.Director;
                    movie.GenreId = m.GenreId;
                    movie.ImageUrl = m.ImageUrl;
                    break;
                }
            }
        }
    }
}
