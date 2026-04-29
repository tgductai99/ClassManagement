using System.Threading.Tasks;
using TaskQLLH.Configuration.Dto;

namespace TaskQLLH.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
