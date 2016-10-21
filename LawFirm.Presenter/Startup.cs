using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LawFirm.Presenter.Startup))]
namespace LawFirm.Presenter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
