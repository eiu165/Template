using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.App.Infastructure;
using Web.Infrastructure.Logging;
using Application.Areas.Admin.Controllers;

namespace Application.App.Attributes
{
	public class OpenCloseDateAttribute : ActionFilterAttribute
	{
	
		public ILogger Logger;

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			//filterContext.HttpContext.Response.Write("Before action:"); 
            var configs = new ConfigsController(null); 
            var startDate = ((IEnumerable<dynamic>)configs.Get("StartDate")).FirstOrDefault().Value; 
            var endDate = ((IEnumerable<dynamic>)configs.Get("EndDate")).FirstOrDefault().Value;
             

			if (startDate == null || endDate == null)
			{
				throw new Exception("Configuration Error: StartDate or EndDate is NULL");
			}

			var parseDate = new DateTime();
			if (DateTime.TryParse(startDate, out parseDate) == false || DateTime.TryParse(endDate, out parseDate) == false)
			{
				throw new Exception("Configuration Error: StartDate or EndDate is not of type DateTime");
			}

			var date = new DateTime();

			if (filterContext.HttpContext.Session["SessionDate"] != null)
			{
				date = DateTime.Parse(filterContext.HttpContext.Session["SessionDate"].ToString());
			}

			else
			{
				date = new DateTimeHelper().GetAdjustedDate; //DateTime.Now;
			}

			var appStart = DateTime.Parse(startDate);
			var appEnd = DateTime.Parse(endDate);

			if (date < appStart)
			{
				//Logger.LogInfo("Coming Soon");
				filterContext.HttpContext.Response.Redirect("/Public/ComingSoon");
			}

			if (date >= appEnd)
			{
				//Logger.LogInfo("Closed");
				filterContext.HttpContext.Response.Redirect("/Public/Closed");
			}




		}
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			//filterContext.HttpContext.Response.Write("After action:");
		}

		public override void OnResultExecuting(ResultExecutingContext filterContext)
		{
			//filterContext.HttpContext.Response.Write("Before result:");
		}

		public override void OnResultExecuted(ResultExecutedContext filterContext)
		{
			//filterContext.HttpContext.Response.Write("After result:");
		}
	}
}