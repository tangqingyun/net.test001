using Basement.Framework.Data;
using SqlMonitoring.Models;
using SqlMonitoring.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SqlMonitoring.Mvc.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Default/
        MonitoringService _MonitoringService = new MonitoringService();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Load() {
            Entity_Monitoring model = _MonitoringService.SingleAsModel();
            return this.Json(model, JsonRequestBehavior.AllowGet); 
        }

    }
}
