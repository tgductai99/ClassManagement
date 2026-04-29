using Abp.AspNetCore.Mvc.ViewComponents;

namespace TaskQLLH.Web.Views
{
    public abstract class TaskQLLHViewComponent : AbpViewComponent
    {
        protected TaskQLLHViewComponent()
        {
            LocalizationSourceName = TaskQLLHConsts.LocalizationSourceName;
        }
    }
}
