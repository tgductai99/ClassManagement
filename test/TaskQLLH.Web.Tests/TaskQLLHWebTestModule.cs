using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TaskQLLH.EntityFrameworkCore;
using TaskQLLH.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace TaskQLLH.Web.Tests
{
    [DependsOn(
        typeof(TaskQLLHWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class TaskQLLHWebTestModule : AbpModule
    {
        public TaskQLLHWebTestModule(TaskQLLHEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TaskQLLHWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(TaskQLLHWebMvcModule).Assembly);
        }
    }
}