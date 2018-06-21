using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cash_Flow.Startup))]
namespace Cash_Flow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
