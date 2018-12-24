using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(WebServer.Startup))]

namespace WebServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Domain security
#if DEBUG
            app.UseCors(CorsOptions.AllowAll);
#endif

            //Token Auth
            //ConfigureAuth(app);
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                Provider = new OAuthProvider(),
                TokenEndpointPath = new PathString("/token")
            };

#if !DEBUG
              options.AccessTokenExpireTimeSpan = TimeSpan.FromHours(4);
#endif

#if DEBUG
            options.AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60);
#endif
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

    }
}
