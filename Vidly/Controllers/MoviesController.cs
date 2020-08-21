using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Linq;
using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(c => c.Gener).ToList();

            return View(movies);
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Movies.Include(c => c.Gener).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult New()//MovieForm
        {
            var geners = _context.Geners.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Geners = geners
            };

            return View(viewModel);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();
            var viewmodel = new MovieFormViewModel(movie)
            {
                Geners = _context.Geners.ToList()
            };

            return View("New", viewmodel);//overriding views
        }

        [HttpPost]
        public ActionResult Save(Movie movie)//model Binding//save
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new MovieFormViewModel(movie)
                {

                    Geners = _context.Geners.ToList()
                };
                return View("New", viewmodel);
            }

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                //TryUpdateModel(customerInDb); Save on the basis of key value pair
                //Mapper.Map(customer,customerInDb)
                movieInDb.Name = movie.Name;
                movieInDb.GenerId = movie.GenerId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = DateTime.Now;
            }


            _context.SaveChanges();


            return RedirectToAction("Index", "Movies");
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}