﻿using System.Web;
using System.Web.Mvc;

namespace _10___HelloWorldAJAX
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
