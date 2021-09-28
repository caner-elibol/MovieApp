using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {      
            return View();
        }
        public IActionResult List()
        {
            var filmListesi = new List<Movie>()
            {
                new Movie
                {
                    Title="Esaretin Bedeli",
                    Description="Kaçma konusu",
                    Director="Kimdi Bilmiyorum",
                    Actors=new string[]{"Brad Pitt","Angelina Jolie"},
                    ImageUrl="1.jpg"
                },
                new Movie
                {
                    Title="Wanted",
                    Description="Suç",
                    Director="Kimdi Bilmiyorum",
                    Actors=new string[]{"Oscar Wilde","Angelina Jolie"},
                    ImageUrl="2.jpg"
                },
                new Movie
                {
                    Title="Recep İvedik",
                    Description="Komedi",
                    Director="Togan Gökbakar",
                    Actors=new string[]{"Şahan Gökbakar","Cem Gecici"},
                    ImageUrl="3.jpg"
                }
            };
            var genre = new List<Genre> {
                new Genre{Name="Macera"},
                new Genre{Name="Komedi"},
                new Genre{Name="Suç"},
                new Genre{Name="Gerilim"},

            };
            var model = new MovieGenreViewModel()
            {
                Movies = filmListesi,
                Genres = genre
            };
            return View("Movies",model);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
