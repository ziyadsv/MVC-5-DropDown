using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DropdownList.Startup))]
namespace DropdownList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
