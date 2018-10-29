using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(WebServer.Startup))]

namespace WebServer
{
    public class Startup
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

        }
    }
}
