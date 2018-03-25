using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductLibrary.Startup))]
namespace ProductLibrary
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
