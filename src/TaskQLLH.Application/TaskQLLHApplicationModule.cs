using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TaskQLLH.Authorization;

namespace TaskQLLH
{
    [DependsOn(
        typeof(TaskQLLHCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TaskQLLHApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TaskQLLHAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TaskQLLHApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
