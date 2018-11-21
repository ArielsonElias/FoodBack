using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodBack_Web.Startup))]
namespace FoodBack_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
