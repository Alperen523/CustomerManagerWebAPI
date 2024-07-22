using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace CustomManagerApiByAlp
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter());
                options.Filters.Add<CustomExceptionFilter>();
            });
        }
    }
    public class CustomExceptionFilter : ExceptionFilterAttribute
        {
            private readonly ILogger<CustomExceptionFilter> _logger;

            public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
            {
                _logger = logger;
            }

            public override void OnException(ExceptionContext context)
            {
                _logger.LogError(context.Exception, "An unhandled exception occurred.");

                context.Result = new ObjectResult(new
                {
                    Error = "An unexpected error occurred.",
                    Details = context.Exception.Message
                })
                {
                    StatusCode = 500
                };
            }
        }
    }
