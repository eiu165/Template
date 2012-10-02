using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Controllers
{
    public class MoviesController : ApplicationController
    { 
        public ActionResult Index()
        {
            return View();
        }


        private IEnumerable<dynamic> GetMoviesFromDb()
        {
            //var articleUrl = Request.UrlReferrer.Segments.Last();
            dynamic table = new Movie();
            var query = @"SELECT     Id, Name, UpdatedAt  FROM         Movie";
            var list = (IEnumerable<dynamic>)table.Query(query);
            return list.AsEnumerable<dynamic>();
        }

        public ActionResult GetMovies()
        {
            var list = GetMoviesFromDb().Select(x => new { name = x.Name, Id = x.Id });
            object movies = new { movies = list };
            //object  movies = new { movies =  new[]
            //{
            //    new  { name ="a" },
            //    new  { name ="b" },
            //    new  { name ="c" },
            //    new  { name ="d" } 
            //} };  
            return DynamicJson(movies);
        }


    }
}
