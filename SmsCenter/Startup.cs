using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmsCenter.Startup))]
namespace SmsCenter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
