using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TaskQLLH.Configuration.Dto;

namespace TaskQLLH.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TaskQLLHAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
