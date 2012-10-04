using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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



        [HttpPost]
        public ContentResult SaveMovies(JObject obj)
        {  
            return Content("success");
        }
//            //var l = new List<dynamic>();
//            //foreach (var k in jsonData.Keys)
//            //{
//            //    l.Add(new ExpandoObject { NameValueCollectionExtensions = });
//            //}
//            bool result = true; 
//            string json = @"{
//              ""Name"": ""Apple"",
//              ""Expiry"": new Date(1230422400000),
//              ""Price"": 3.99,
//              ""Sizes"": [
//                ""Small"",
//                ""Medium"",
//                ""Large""
//              ]
//            }";

//            JObject o = JObject.Parse(json);
//            string name = (string)o["Name"];
//            // Apple 
//            JArray sizes = (JArray)o["Sizes"];
//            var num = sizes.Count;
//            string smallest = (string)sizes[0];
//            // Small 


//            //List<PersonData> personData;
//            //personData = jss.Deserialize<List<PersonData>>(jsonData); 
//            return Content(result.ToString());
//        }






    }
}
