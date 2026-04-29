using System.Threading.Tasks;
using Abp.Application.Services;
using TaskQLLH.Authorization.Accounts.Dto;

namespace TaskQLLH.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
