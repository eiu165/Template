using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using Web.App.Models;
using Web.App.Infastructure;
using System.Web.Script.Serialization;
using Web.Infrastructure; 

namespace Web.Areas.Admin.Controllers
{
    public class UsersController : Controller 
    {

        /*
        SELECT     UserProfile.UserId, UserProfile.UserName, webpages_OAuthMembership.UserId AS OAuth_UserId, webpages_OAuthMembership.Provider, 
                      webpages_OAuthMembership.ProviderUserId, webpages_Membership.UserId AS Membership_UserId, webpages_Membership.CreateDate, 
                      webpages_Membership.ConfirmationToken, webpages_Membership.IsConfirmed, webpages_Membership.LastPasswordFailureDate, 
                      webpages_Membership.PasswordFailuresSinceLastSuccess, webpages_Membership.PasswordChangedDate, 
                      webpages_Membership.PasswordVerificationTokenExpirationDate
FROM         UserProfile LEFT OUTER JOIN
                      webpages_OAuthMembership ON UserProfile.UserId = webpages_OAuthMembership.UserId LEFT OUTER JOIN
                      webpages_Membership ON UserProfile.UserId = webpages_Membership.UserId
         */

        public ActionResult Index()
        {
            return View();
        }



        private IEnumerable<dynamic> GetUsersFromDb()
        {
            var articleUrl = Request.UrlReferrer.Segments.Last();
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
            var l = GetUsersFromDb();

            return DynamicJson( (l));
          //return Json(new { title = "aaa", list = l }, JsonRequestBehavior.AllowGet);
         // return Json(l, JsonRequestBehavior.AllowGet);
          //return new JsonDataContractActionResult(  l );
          //{ data = l };
          //return new Newtonsoft.Json.
            /*JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.RegisterConverters(new JavaScriptConverter[] { new DynamicJsonConverter() });
 
            dynamic glossaryEntry = jss.Deserialize(json, typeof(object)) as dynamic;*/
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
