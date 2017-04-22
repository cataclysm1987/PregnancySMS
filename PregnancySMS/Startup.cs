using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PregnancySMS.Startup))]
namespace PregnancySMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
