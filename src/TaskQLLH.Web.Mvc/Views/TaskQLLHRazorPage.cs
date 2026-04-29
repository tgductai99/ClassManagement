using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace TaskQLLH.Web.Views
{
    public abstract class TaskQLLHRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected TaskQLLHRazorPage()
        {
            LocalizationSourceName = TaskQLLHConsts.LocalizationSourceName;
        }
    }
}
