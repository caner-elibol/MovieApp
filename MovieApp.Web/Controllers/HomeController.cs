using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string imageURL = "1.jpg";
            string filmBasligi = "film basligi";
            string filmAciklama = "filmin aciklamasi";
            string filmYonetmeni = "Yönetmen";
            string[] oyuncular =
            {
                "oyuncu 1",
                "oyuncu 2"
            };
            var m = new Movie();
            
            m.Title = filmBasligi;
            m.Description = filmAciklama;
            m.Director = filmYonetmeni;
            m.Actors = oyuncular;
            m.ImageUrl = imageURL;
            
            return View(m);
        }
        public IActionResult About()
        { 
            return View();
        }
    }
}
