using Microsoft.Extensions.DependencyInjection;

namespace CustomManagerApiByAlp
{
    public static class FormatterConfig
    {
        public static void RegisterFormatters(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.WriteIndented = true;
                });
        }
    }
}
