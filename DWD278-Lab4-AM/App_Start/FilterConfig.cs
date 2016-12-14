using System.Web;
using System.Web.Mvc;

namespace DWD278_Final_Hotel_Rooms
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
