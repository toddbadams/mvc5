using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lostsocks.Startup))]
namespace lostsocks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
