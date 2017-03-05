using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AttandanceProject.Startup))]
namespace AttandanceProject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
