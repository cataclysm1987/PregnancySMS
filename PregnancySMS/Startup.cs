using FluentScheduler;
using Microsoft.Owin;
using Owin;
using PregnancySMS.Models;

[assembly: OwinStartupAttribute(typeof(PregnancySMS.Startup))]
namespace PregnancySMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            JobManager.Initialize(new MyRegistry());
        }
    }

    public class MyRegistry : Registry
    {

    }

    internal class DailyAlert : IJob
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Execute()
        {
            
        }
    }
}
