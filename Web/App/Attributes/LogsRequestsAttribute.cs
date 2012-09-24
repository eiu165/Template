using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Infrastructure.Logging;
using System.Threading;
using System.Web.Mvc;

namespace Application.App.Attributes
{
	public class LogsRequestsAttribute : ActionFilterAttribute, IActionFilter
	{
		private static ILogger log;

		void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
		{
			ThreadPool.QueueUserWorkItem(delegate
			{
				try
				{
					string message =
					string.Format(
					"Action= \"{0}\", Controller= \"{1}\", IPAddress= \"{2}\"" +
					"TimeStamp= \"{3}\"",
					filterContext.RouteData.Values["action"] as string,
					filterContext.Controller.ToString(),
					filterContext.HttpContext.Request.UserHostAddress,
					filterContext.HttpContext.Timestamp);

					log.LogInfo(message);
				}
				finally
				{
				}
			});
		}

		void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
		{
			if (filterContext.Exception != null)
			{
				ThreadPool.QueueUserWorkItem(delegate
				{
					try
					{
						string message = filterContext.Exception.Message;
						log.LogInfo(message);
					}
					finally
					{
					}
				});
			}
		}
	}
}