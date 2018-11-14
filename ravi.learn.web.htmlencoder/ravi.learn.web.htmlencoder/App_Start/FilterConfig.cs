using System.Web;
using System.Web.Mvc;

namespace ravi.learn.web.htmlencoder
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
