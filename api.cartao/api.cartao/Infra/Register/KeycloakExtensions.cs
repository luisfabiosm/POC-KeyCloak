using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Sdk.Admin;

namespace Infra.Register
{
    public static class KeycloakExtensions
    {

        public static IServiceCollection AddKeycloakAuth(this IServiceCollection services, IConfiguration configuration, WebApplicationBuilder builder)
        {
            var authenticationOptions = builder
                              .Configuration
                              .GetSection(KeycloakAuthenticationOptions.Section)
                              .Get<KeycloakAuthenticationOptions>();

            builder.Services.AddKeycloakAuthentication(authenticationOptions);

            var authorizationOptions = builder
                                        .Configuration
                                        .GetSection(KeycloakProtectionClientOptions.Section)
                                        .Get<KeycloakProtectionClientOptions>();

            builder.Services.AddKeycloakAuthorization(authorizationOptions);

            var adminClientOptions = builder
                             .Configuration
                             .GetSection(KeycloakAdminClientOptions.Section)
                             .Get<KeycloakAdminClientOptions>();

            builder.Services.AddKeycloakAdminHttpClient(adminClientOptions);

            //builder.Services
            //    .AddAuthorization(o => o.AddPolicy("IsAdmin", b =>
            //    {
            //        b.RequireRealmRoles("admin");
            //        b.RequireResourceRoles("r-admin");
            //        // TokenValidationParameters.RoleClaimType is overriden
            //        // by KeycloakRolesClaimsTransformation
            //        b.RequireRole("r-admin");
            //    }))
            //    .AddKeycloakAuthorization(authorizationOptions);

            return services;
        }
    }
}
