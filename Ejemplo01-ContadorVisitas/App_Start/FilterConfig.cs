﻿using System.Web;
using System.Web.Mvc;

namespace Ejemplo01_ContadorVisitas
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
