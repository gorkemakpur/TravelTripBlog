﻿using System.Web;
using System.Web.Mvc;

namespace Travel_Trip_Blog_Website
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
