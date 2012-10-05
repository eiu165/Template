using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http; 

namespace Web.Controllers
{
    public class AlbumsController : ApiController
    { 

        [HttpPost]
        public string Post(JObject jsonData)
        {
            return "success";
            //dynamic json = jsonData;
            //JObject jalbum = json.Album;
            //JObject juser = json.User;
            //string token = json.UserToken;

            //var album = jalbum.ToObject<Album>();
            //var user = juser.ToObject<User>();

            //return String.Format("{0} {1} {2}", album.AlbumName, user.Name, token);
        }

        //[HttpGet]
        //public JObject Get()
        //{  
        //    //object people = new { people = GetUsersFromDb().Select(x => new { name = x.UserName, Id = x.UserId }) };
        //    object people = new
        //    {
        //        people = new[]
        //        {
        //            new  { name ="a" },
        //            new  { name ="b" },
        //            new  { name ="c" },
        //            new  { name ="d" } 
        //        }
        //    };  
        //    return  people;  
        //} 

    } 

}
