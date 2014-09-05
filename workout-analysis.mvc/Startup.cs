using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(workout_analysis.mvc.Startup))]
namespace workout_analysis.mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
