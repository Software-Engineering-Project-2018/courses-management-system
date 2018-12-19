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
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors();
        }
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
                TokenEndpointPath = new PathString("/token"),
                Provider = new OAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(2)
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
