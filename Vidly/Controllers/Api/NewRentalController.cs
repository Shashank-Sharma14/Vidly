using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreatNewRental(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRentalDto.CustomerId);

            if (newRentalDto.MovieIds.Count == 0)
                return BadRequest("No Movie Ids Have been Pass");

            if (customer == null)
                return BadRequest("CustomerId is not valid");

            var movies = _context.Movies.Where(c => newRentalDto.MovieIds.Contains(c.Id)).ToList();/*Select * from movies where Id in(1,2,3)*/

            if(movies.Count!= newRentalDto.MovieIds.Count)
                return BadRequest("One oR more MovieIds is Invalid");

            foreach (var movie in movies)
            {

                if (movie.NumberAvailable==0)
                    return BadRequest("Movie is out Of Stock");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DayRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
