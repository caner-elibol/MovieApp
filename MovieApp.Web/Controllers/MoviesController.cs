using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;
using MovieApp.Web.Entity;
using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;
        public MoviesController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {      
            return View();
        }
        public IActionResult List(int? id,string q)   //nullable id
        {
            //var controller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var genreid = RouteData.Values["id"];

            //var movies = MovieRepository.Movies;
            var movies = _context.Movies.AsQueryable();
            if (id!=null)
            {
                movies = movies
                    .Include(m=>m.Genres)
                    .Where(m => m.Genres.Any(g=>g.GenreId==id));
            }
            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(i =>
                  i.Title.ToLower().Contains(q.ToLower()) ||
                  i.Description.ToLower().Contains(q.ToLower()));
            }
            var model = new MoviesViewModel()
            {
                Movies = movies.ToList()
                
            };
            
            return View("Movies",model);
        }
        public IActionResult Details(int id)
        {
            return View(_context.Movies.Find(id));
        }
        public IActionResult Create()
        {
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie m)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(m);
                _context.SaveChanges();
                
                TempData["Message"] = $"{m.Title} Adlı Film Eklendi";
                return RedirectToAction("list", "movies");
            }
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View();
            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View(_context.Movies.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                
                _context.Movies.Update(m);
                _context.SaveChanges();
                //MovieRepository.Edit(m);
                TempData["Message"] = $"{m.Title} Adlı Film Düzenlendi";
                return RedirectToAction("details", "movies", new { @id = m.MovieId });
            }
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View(m);
            
        }
        [HttpPost]
        public IActionResult MovieDelete(int MovieId, string Title)
        {
            var entity = _context.Movies.Find(MovieId);// silinecek movieyi bulduk

            _context.Movies.Remove(entity);//sildik
            _context.SaveChanges();//kaydetmezsen silinme işlemi tamamlanmaz.
            //MovieRepository.Delete(MovieId);
            TempData["Message"] = $"{Title} isimli film silindi";
            return RedirectToAction("movielist", "admin");

        }

    }
}
