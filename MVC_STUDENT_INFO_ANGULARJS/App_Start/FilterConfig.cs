using System.Web.Mvc;

namespace MVC_STUDENT_INFO_ANGULARJS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
