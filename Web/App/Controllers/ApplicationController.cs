using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using System.Web.Script.Serialization;
using System.IO;
using System.Dynamic;
using Web.Infrastructure.Logging;
using Web.Infrastructure;
using Web.Models; 
using Web.App.Infrastructure;

namespace Web.App.Controllers
{
    public class ApplicationController : Controller
    {
        public ITokenHandler TokenStore;
        public ILogger Logger;

        public ApplicationController(ITokenHandler tokenStore, ILogger logger)
        {
            TokenStore = tokenStore;
            Logger = logger;
            //initialize this
            //ViewBag.CurrentUser = CurrentUser ?? new {Email = ""};
        }

        public ApplicationController(ITokenHandler tokenStore) : this(tokenStore, new NLogger("ApplicationController")) { }

        public ApplicationController():this(new FormsAuthTokenStore()) {}

        private string prospectIdSessionString = "prospectIdSessionString";
        public int? SessionProspectId
        {
            get
            {
                return HttpContext.Session[prospectIdSessionString] == null
                           ? (int?)null
                           : Convert.ToInt32(HttpContext.Session[prospectIdSessionString]);
            }
            set { HttpContext.Session[prospectIdSessionString] = value; }
        }

		private string sessionBirthDayString = "sessionBirthDayString";
		public DateTime? SessionBirthDay
		{
			get
			{
				return HttpContext.Session[sessionBirthDayString] == null
						   ? (DateTime?)null
						   : Convert.ToDateTime(HttpContext.Session[sessionBirthDayString]);
			}
			set { HttpContext.Session[sessionBirthDayString] = value; }
		}


		private string submissionIdSessionString = "submissionIdSessionString";
		public int? SessionSubmissionId
		{
			get
			{
				return HttpContext.Session[submissionIdSessionString] == null
						   ? (int?)null
						   : Convert.ToInt32(HttpContext.Session[submissionIdSessionString]);
			}
			set { HttpContext.Session[submissionIdSessionString] = value; }
		}




        public ActionResult ToJson(dynamic content)
        {
            var json = ToJsonString(content);
            Response.ContentType = "application/json";
            return Content(json);
        }

        public static string ToJsonString(dynamic content)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] {new ExpandoObjectConverter()});
            var json = serializer.Serialize(content);
            return json;
        }

        public string ReadJson() {
            var bodyText = "";
            using (var stream = Request.InputStream) {
                stream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(stream))
                    bodyText = reader.ReadToEnd();
            }
            return bodyText;
        }
        public dynamic SqueezeJson()
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new ExpandoObjectConverter() });
            var bodyText = "";
            using (var stream = Request.InputStream)
            {
                stream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(stream))
                    bodyText = reader.ReadToEnd();
            }
            return serializer.Deserialize(bodyText, typeof(ExpandoObject));
        }

        //public ActionResult CSV(IEnumerable<dynamic> data, string fileName) {
        //    return new CSVResult(data, fileName);
        //}

        protected override void OnException(ExceptionContext filterContext)
        {
            Logger.LogError(filterContext.Exception.ToString());
        }
         
    }
}
