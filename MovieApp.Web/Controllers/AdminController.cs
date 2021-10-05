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
    public class AdminController : Controller
    {
        private readonly MovieContext _context;
        public AdminController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MovieList()
        {
            return View(new AdminMoviesViewModel
            {
                Movies = _context.Movies
                .Include(m => m.Genres)
                .Select(m => new AdminMovieViewModel
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    ImageUrl = m.ImageUrl,
                    Genres = m.Genres.ToList()
                })
                .ToList()
            });
        }
        public IActionResult MovieUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _context.Movies.Select(m => new AdminEditMovieViewModel
            {
                MovieId = m.MovieId,
                Title = m.Title,
                Description = m.Description,
                ImageUrl = m.ImageUrl,
                SelectedGenres=m.Genres
            }).FirstOrDefault(m => m.MovieId == id);

            ViewBag.Genres = _context.Genres.ToList();
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);

        }
        [HttpPost]
        public IActionResult MovieUpdate(AdminEditMovieViewModel m,int[] genreIds)
        {
            var entity = _context.Movies.Include("Genres").FirstOrDefault(c=>c.MovieId==m.MovieId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Title = m.Title;
            entity.Description = m.Description;
            entity.ImageUrl = m.ImageUrl;
            entity.Genres = genreIds.Select(id => _context.Genres.FirstOrDefault(i => i.GenreId == id)).ToList();

            _context.SaveChanges();
            TempData["Message"] = $"{m.Title} Adlı Film Düzenlendi";
            return RedirectToAction("movielist", "admin", new { @id = m.MovieId });

        }
        [HttpPost]
        public IActionResult MovieDelete(int MovieId, string Title)
        {
            var entity = _context.Movies.Find(MovieId);// silinecek movieyi bulduk
            if (entity == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(entity);//sildik
            _context.SaveChanges();//kaydetmezsen silinme işlemi tamamlanmaz.
            //MovieRepository.Delete(MovieId);
            TempData["Message"] = $"{Title} isimli film silindi";
            return RedirectToAction("movielist", "admin");

        }

        public IActionResult GenreList()
        {
            return View(new AdminGenresViewModel
            {
                Genres = _context.Genres.Select(g => new AdminGenreViewModel
                {
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Count = g.Movies.Count(),
                    Movies = g.Movies.ToList()
                }).ToList()
            }) ;
        }
        public IActionResult GenreUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _context
                .Genres
                .Select(g => new AdminEditGenreViewModel {
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Movies = g.Movies.Select(i => new AdminMovieViewModel {
                        MovieId = i.MovieId,
                        Title = i.Title,
                        ImageUrl = i.ImageUrl
                    }).ToList()
                })
                .FirstOrDefault(g => g.GenreId == id);
            //    .Select(m => new AdminEditGenreViewModel
            //{
            //    GenreId = m.GenreId,
            //    Name = m.Name,             
            //    SelectedMovies = m.Movies.ToList()
            //}).FirstOrDefault(m => m.GenreId == id);

            //ViewBag.Movies = _context.Movies.ToList();
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);

        }
        [HttpPost]
        public IActionResult GenreUpdate(AdminEditGenreViewModel m)
        {
            var entity = _context.Genres.FirstOrDefault(c => c.GenreId == m.GenreId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = m.Name;

            _context.SaveChanges();
            TempData["Message"] = $"{m.Name} Adlı Kategori Düzenlendi";
            return RedirectToAction("genrelist");

        }
        //public IActionResult MovieCreate()
        //{

        //    ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult MovieCreate(AdminCreateMovieViewModel m)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Movies.Add(m);
        //        _context.SaveChanges();

        //        TempData["Message"] = $"{m.Title} Adlı Film Eklendi";
        //        return RedirectToAction("list", "movies");
        //    }
        //    ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
        //    return View();

        //}
    }
}
