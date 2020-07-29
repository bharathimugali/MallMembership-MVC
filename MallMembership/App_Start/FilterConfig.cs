using MallMembership.CustomFilter;
using System.Web;
using System.Web.Mvc;

namespace MallMembership
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomExceptionFilter());
        }
    }
}
