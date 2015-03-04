using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yun.shop.domain;
using yun.shop.manager;


namespace yun.shop.controllers.Controllers
{
    public class HomeController : Controller
    {
        
        CategoryManager bll = new CategoryManager();
        public ActionResult Index()
        {
            var list = bll.GetCategoryAll();           
            return View(list);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View();
        }
    }
}
