using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VidlyWithAuthentication.Dtos;
using VidlyWithAuthentication.Models;

namespace VidlyWithAuthentication.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //actions
        //POST
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            ////edge case 01: no movies are given when renting
            //if (newRental.MovieIds.Count == 0)
            //    return BadRequest("No movie Ids have been given");


            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);


            ////edge case 02: no customer matches
            //if (customer == null)
            //    return BadRequest("Customer Id is not available");



            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();


            ////edge case 03: invalid movies 
            //if (movies.Count != newRental.MovieIds.Count)
            //    return BadRequest("One or more movie Ids are invalid");



            //we get the movies now we iterate over them
            foreach (var movie in movies)
            {

                //edge case 04: movie is out of stock
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

    }
}