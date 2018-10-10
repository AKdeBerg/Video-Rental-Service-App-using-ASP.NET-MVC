using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyWithAuthentication.Models;
using VidlyWithAuthentication.ViewModels;
using System.Data.Entity;

using System.Data.Entity.Validation;

namespace VidlyWithAuthentication.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        //[Authorize(Roles = RoleName.CanManageMovies)] I have changed it 
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            else
                return View("ReadOnlyList");
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genre = _context.Genre.ToList();

            var viewModel = new MovieFormViewModel()
            {

                Genre = genre
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            //if the model state is not valid then we will return the same view which the movie form
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {

                    Genre = _context.Genre.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0) //Id is a hidden field. If it's zero then the movie is new
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else //otherwise it's an existing movie so we need to update it
            {
                //fetch the movie from database
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {

                Genre = _context.Genre.ToList()
            };
            return View("MovieForm", viewModel);
        }
    }
}