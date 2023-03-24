using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace ProjectTracking.Identity;

public static class Configuration
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("ProjectsWebApi", "Web API")
        };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiResource> ApiResources =>
    new List<ApiResource>
    {
        new ApiResource("ProjectsWebAPI","Web API",new []{JwtClaimTypes.Name})
        {
            Scopes = {"ProjectsWebAPI"}
        }
    };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "projects-web-api",
                ClientName = "Projects Web",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequirePkce = true,
                RedirectUris =
                {
                    "http://.../signin-oidc"
                },
                AllowedCorsOrigins =
                {
                    "http://"
                },
                PostLogoutRedirectUris =
                {
                    "http://.../signout-oidc"
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "ProjectsWebAPI"
                },
                AllowAccessTokensViaBrowser = true
            }
        };


}