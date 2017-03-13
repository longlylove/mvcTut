using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer {Name = "Tylar"},
                new Customer {Name = "Endo"},
                new Customer {Name = "0"},
                new Customer {Name = "1"},
                new Customer {Name = "2"},
                new Customer {Name = "3"},
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //View data dictionary, pass data to the view
            // DO NOT use view data or view bag.. bcz it is f******* ugly
            //ViewData["Movie"] = movie;
            //ViewBag.

            var viewResult = new ViewResult();
            //viewResult.ViewData.Model

            return View(viewModel);
            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();

            // Name of the action, Controller, Argument for target action
            //return RedirectToAction("Index","Home", new {page = 1, sortBy = "name"});
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //movies
        //pageIndex ? is nullable
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }

        //Quickly create an action:
        //- Type mvcaction4
        //- Click Tab

        //Regex with multiple constraints
        [Route("movies/released/{year}/{month:regex(\\d{4}:range(1,12))}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}