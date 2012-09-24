using System;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Web.Infrastructure; 
using NLog; 
using System.Collections.Generic;
using Web.Attributes;
using Web.App.Infrastructure;
using Application.Models; 

namespace Application.Areas.Admin.Controllers
{

    [AuthorizeByRole(Roles = "Dev,Config,ConfigEdit")] 
    public class ConfigsController : CruddyController
    {
        private static readonly Logger Log = LogManager.GetLogger(typeof(ConfigsController).Name);

        public ConfigsController(ITokenHandler tokenStore) : base(tokenStore)
        {
            _table = new Application.Models.Config();
            ViewBag.Table = _table;
        }

          
        public ActionResult About()
        {
            return View();
        }


        [AuthorizeByRole(Roles = "Dev,Config")]
        public override ViewResult Index( )
        {
            return base.Index( );
        }
		[AuthorizeByRole(Roles = "Dev,ConfigEdit")]
        public override ActionResult Edit(int id)
        {
            return base.Edit(id);
        }
		[AuthorizeByRole(Roles = "Dev,Config")]
        public override ActionResult Details(int id)
        {
            return base.Details(id);
        }


        public virtual dynamic Get(string name)
        {
            Func<dynamic, bool> check = x => x.Name == name;
            return Enumerable.Where<dynamic>(this.Get(), check);
        }
         


        protected override dynamic Get(int id)
        {
            Func<dynamic, bool> check = x => x.ID == id;
            return Enumerable.FirstOrDefault<dynamic>(this.Get(), check); 
        }

        protected override dynamic Get()
        {
            const string key = "Config";
            var ret = HttpRuntime.Cache[key]; 
            if (ret == null)
            {
                ret = _table.All();
                Log.Info("getting config from database");
                HttpRuntime.Cache.Add(key, ret, null, DateTime.Now.AddMinutes(1), Cache.NoSlidingExpiration,CacheItemPriority.Low,RemovedCallback);
            }
            return ret; 
        } 
        public static void RemovedCallback(String k, Object v, CacheItemRemovedReason r)
        {
            //var s = string.Format("Key:{0} Reason:{2} Object:{1} ", k, v.ToString(), r);
            //Log.Info(s);
        }


        [HttpGet]
        public ActionResult AjaxRead(KendoGridBinder.KendoGridRequest request)
        {
            var list = ((IEnumerable<dynamic>)this.Get()).Select(x => new ConfigDto
            {
                Name = x.Name,
                Value = x.Value,
                UpdatedAt = x.UpdatedAt 
            }); 
            /*
            var fromdb = ((Log)_table).All();
            var dto = fromdb.Select(x => new LogDto
            {
                UpdatedAt = x.UpdatedAt,
                UpdatedAtString = x.UpdatedAt.ToString(), 
                IpAddress = x.IpAddress, Level = x.Level, Server = x.Server, 
                Session=x.Session, UserName= x.UserName, 
                Summary = x.Summary, Id = x.Id, 
                Email = x.Email 
            }).OrderByDescending(x => x.UpdatedAt);*/
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AjaxDestroy(FormCollection fc)
        {
            var s = fc;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AjaxUpdate(FormCollection fc)
        {
            var s = fc;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AjaxCreate(FormCollection fc)
        {
            var s = fc;
            return RedirectToAction("Index");
        }
 




    }
}

