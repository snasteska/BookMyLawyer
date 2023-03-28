using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookMyLawyer.Startup))]
namespace BookMyLawyer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
