using System.Web;
using System.Web.Mvc;

namespace AspDotNetCourseApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RequireHttpsAttribute());   // make sure our site in available ONLY through HTTPS
        }
    }
}
