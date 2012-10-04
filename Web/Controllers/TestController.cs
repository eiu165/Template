using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class TestController :  Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        //[System.Web.Http.HttpPostAttribute]
        //public string PostAlbum(JObject jsonData)
        //{
        //    dynamic json = jsonData;
        //    JObject jalbum = json.Album;
        //    JObject juser = json.User;
        //    string token = json.UserToken;

        //    var album = jalbum.ToObject<Album>();
        //    var user = juser.ToObject<User>();

        //    return String.Format("{0} {1} {2}", album.AlbumName, user.Name, token);
        //}


    }
}
