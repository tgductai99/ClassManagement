using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TaskQLLH.Configuration;

namespace TaskQLLH.Web.Host.Startup
{
    [DependsOn(
       typeof(TaskQLLHWebCoreModule))]
    public class TaskQLLHWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TaskQLLHWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TaskQLLHWebHostModule).GetAssembly());
        }
    }
}
