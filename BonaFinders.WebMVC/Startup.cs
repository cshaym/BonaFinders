using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BonaFinders.WebMVC.Startup))]
namespace BonaFinders.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
