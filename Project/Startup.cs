using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GAForecast.Startup))]
namespace GAForecast
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
