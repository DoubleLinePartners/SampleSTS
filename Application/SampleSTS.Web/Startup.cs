using Microsoft.Owin;
using Owin;
using SampleSTS.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace SampleSTS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
