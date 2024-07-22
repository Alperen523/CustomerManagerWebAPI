using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace CustomManagerApiByAlp
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
