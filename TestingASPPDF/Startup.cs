using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestingASPPDF.Startup))]
namespace TestingASPPDF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
