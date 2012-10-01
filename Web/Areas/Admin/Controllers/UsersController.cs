using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Web.App.Models;
using Web.App.Infastructure;
using System.Web.Script.Serialization;
using Web.Infrastructure; 

namespace Web.Areas.Admin.Controllers
{
    public class UsersController : Controller 
    {

        public ActionResult Index()
        {
            return View();
        }



        private IEnumerable<dynamic> GetUsersFromDb()
        {
            //var articleUrl = Request.UrlReferrer.Segments.Last();
            dynamic table = new UserProfile();
            var query = @"
        SELECT     UserProfile.UserId, UserProfile.UserName, webpages_OAuthMembership.UserId AS OAuth_UserId, webpages_OAuthMembership.Provider, 
                      webpages_OAuthMembership.ProviderUserId, webpages_Membership.UserId AS Membership_UserId, webpages_Membership.CreateDate, 
                      webpages_Membership.ConfirmationToken, webpages_Membership.IsConfirmed, webpages_Membership.LastPasswordFailureDate, 
                      webpages_Membership.PasswordFailuresSinceLastSuccess, webpages_Membership.PasswordChangedDate, 
                      webpages_Membership.PasswordVerificationTokenExpirationDate
FROM         UserProfile LEFT OUTER JOIN
                      webpages_OAuthMembership ON UserProfile.UserId = webpages_OAuthMembership.UserId LEFT OUTER JOIN
                      webpages_Membership ON UserProfile.UserId = webpages_Membership.UserId";
            var list = (IEnumerable<dynamic>)table.Query(query); 
            return list.AsEnumerable<dynamic>();
        }

        public ActionResult GetUsers()
        { 
            var list = GetUsersFromDb().Select(x => new { name = x.UserName, Id = x.UserId });
            object  people = new { people =  list }; 
            //object  people = new { people =  new[]
            //{
            //    new  { name ="a" },
            //    new  { name ="b" },
            //    new  { name ="c" },
            //    new  { name ="d" } 
            //} };  
            return DynamicJson(people);  
        }


        public ActionResult DynamicJson(dynamic content)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new ExpandoObjectConverter() });
            var json = serializer.Serialize(content);
            Response.ContentType = "application/json";
            return Content(json);
        }

    }
}
