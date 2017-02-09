using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZenithWebsite.Startup))]
namespace ZenithWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
