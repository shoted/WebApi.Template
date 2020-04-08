using System.Web.Mvc;
using Lexun.Template.Api.Attributes;

namespace WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LoginCheckAttribute());
        }
    }
}
