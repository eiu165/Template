using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.App.Attributes
{
	public class ShowMessageAttibute : ActionFilterAttribute
	{
		public string Message { get; set; }

		 
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			filterContext.HttpContext.Response.Write("Before action:" + Message);

		}
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			filterContext.HttpContext.Response.Write("After action:" + Message);
		}

		public override void OnResultExecuting(ResultExecutingContext filterContext)
		{
			filterContext.HttpContext.Response.Write("Before result:" + Message);
		}

		public override void OnResultExecuted(ResultExecutedContext filterContext)
		{
			filterContext.HttpContext.Response.Write("After result:" + Message);
		}
	}
}