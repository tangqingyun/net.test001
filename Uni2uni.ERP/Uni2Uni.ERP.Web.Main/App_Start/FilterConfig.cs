﻿using System.Web;
using System.Web.Mvc;

namespace Uni2Uni.ERP.Web.Main
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}