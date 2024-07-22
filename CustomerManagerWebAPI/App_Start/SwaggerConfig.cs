using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CustomManagerApiByAlp
{
    public static class SwaggerConfig
    {
        public static void RegisterSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }
    }
}
