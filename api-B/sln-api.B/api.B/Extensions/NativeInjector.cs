
using Domain.Contracts;
using Domain.Services;

namespace Extensions
{
    public static class NativeInjector
    {

        public static IServiceCollection AddDomainAdapter(this IServiceCollection service)
        {
            service.AddScoped<IPixService, PixService>();
     
            return service;
        }
    }
}
