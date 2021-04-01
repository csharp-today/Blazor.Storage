using Microsoft.Extensions.DependencyInjection;

namespace CSharpToday.Blazor.Storage
{
    public static class Extension
    {
        public static IServiceCollection AddBlazorStorage(this IServiceCollection services) => services
            .AddScoped<IBrowserStorage, BrowserStorage>();
    }
}
