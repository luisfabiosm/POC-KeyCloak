

namespace Infra.Register
{
    public static class ApiNativeInjection
    {

        public static IServiceCollection AddAPIExtensions(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAdapters(configuration);
            services.AddEndpointsApiExplorer();
            services.AddDomainAdapter();
            services.AddHttpContextAccessor();
            services.AddSwaggerAdapter();

            services.AddAuthorization();

            return services;
        }

        public static void UseAPIExtensions(this WebApplication app)
        {
            if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Development" || app.Environment.EnvironmentName == "Local" || app.Environment.EnvironmentName == "Fabrica")
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.AddHttpEndpointAdapter();

        }
    }
}
