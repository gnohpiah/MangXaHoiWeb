using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MangXaHoiWeb.Models.Authentication
{
    public class Authentication:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("MaNguoiDung") == null)
            {
                context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    {"Controller","Access"},
                    {"Action","Login"}
                });
            }
        }
    }
}
