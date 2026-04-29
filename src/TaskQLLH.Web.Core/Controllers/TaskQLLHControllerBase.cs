using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TaskQLLH.Controllers
{
    public abstract class TaskQLLHControllerBase: AbpController
    {
        protected TaskQLLHControllerBase()
        {
            LocalizationSourceName = TaskQLLHConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
