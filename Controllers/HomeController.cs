using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moody413Assignment3.Models;
using Moody413Assignment3.Models.ViewModels;
//using static Moody413Assignment3.Models.ViewModels.EditMovieViewModel;

//the home controller!

namespace Moody413Assignment3.Controllers
{
    public class HomeController : Controller
    {
        //private variable for the class
        private MovieListDbContext context { get; set; }

        //constructor for the class
        public HomeController(MovieListDbContext con)
        {
            context = con;
        }

        //delete this bc you can only have one controller constructor
            //private readonly ILogger<HomeController> _logger;

            //public HomeController(ILogger<HomeController> logger)
            //{
             //   _logger = logger;
            //}

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Movies()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Movies(FormResponse appResponse)
        {
            //makes it so the fields are required
            if (ModelState.IsValid)
            {
                context.Movie.Add(appResponse);
                context.SaveChanges();
                //return View("Confirmation", appResponse);
                }
            //else
            //{
                return View();
            //}
            
        }

        public IActionResult MovieList()
        {
                    //this displays everything, except the movie Independence Day, which I actually think is a g8 movie
            return View(context.Movie);//TempStorage.Applications.Where(r => r.Title != "Independence Day"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        //button to freaking delete the record
        [HttpPost]
        public IActionResult Delete(int deletestuff)
        {
            FormResponse x = context.Movie.Single(x => x.MovieID == deletestuff);

            if (ModelState.IsValid)
            {
                context.Movie.Remove(x);
                context.SaveChanges();
            }
            //returns the movie list view
            return RedirectToAction("MovieList");
        }

        [HttpPost]
        public IActionResult EditMovie(int editstuff, string category, string title,
            int year, string director, string rating, bool edited, string lentto, string notes)
        {
            //FormResponse x = context.Movie.Single(x => x.MovieID == editstuff);

            //if (ModelState.IsValid)
            //{
                //context.Movie.Remove(x);
                //context.SaveChanges();
            //}
            //returns the movie list view
            return View("EditMovie", new FormResponse
            {
                MovieID = editstuff,
                Category = category,
                Title = title,
                Year = year,
                Director = director,
                Rating = rating,
                Edited = edited,
                LentTo = lentto,
                Notes = notes

                
            });

            //context.Movie.Update(context.Movie.Single(x => x.MovieID == editstuff));
            //context.SaveChanges();
        }

        [HttpPost]
        public IActionResult UpdateMovie(int editstuff, FormResponse movie)
        {
            //updates the info in the DB

                context.Movie.Where(e => e.MovieID == editstuff).FirstOrDefault().Category = movie.Category;
                context.Movie.Where(e => e.MovieID == editstuff).FirstOrDefault().Title = movie.Title;
                context.Movie.Where(e => e.MovieID == editstuff).FirstOrDefault().Year = movie.Year;
                context.Movie.Where(e => e.MovieID == editstuff).FirstOrDefault().Director = movie.Director;
                context.Movie.Where(e => e.MovieID == editstuff).FirstOrDefault().Rating = movie.Rating;
                context.Movie.Where(e => e.MovieID == editstuff).FirstOrDefault().Edited = movie.Edited;
                context.Movie.Where(e => e.MovieID == editstuff).FirstOrDefault().LentTo = movie.LentTo;
                context.Movie.Where(e => e.MovieID == editstuff).FirstOrDefault().Notes = movie.Notes;

                context.SaveChanges();
            


            return RedirectToAction("MovieList");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
