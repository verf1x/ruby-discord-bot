using Microsoft.Extensions.DependencyInjection;

namespace RubyBot.Application.Extensions;

public static class DependencyInjectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddApplication()
        {
            return services.AddHandlers(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}