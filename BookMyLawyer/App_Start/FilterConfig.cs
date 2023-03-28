using System.Web;
using System.Web.Mvc;

namespace BookMyLawyer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // avtorizationa na cela webapp
            //filters.Add(new AuthorizeAttribute());
        }
    }
}
