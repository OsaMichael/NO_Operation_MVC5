using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NoOperation_MVC.Startup))]
namespace NoOperation_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
