using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ForumItMVC.Startup))]
namespace ForumItMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
