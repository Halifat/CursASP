using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(curs.Startup))]
namespace curs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
