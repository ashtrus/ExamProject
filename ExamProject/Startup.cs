using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamProject.Startup))]
namespace ExamProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
