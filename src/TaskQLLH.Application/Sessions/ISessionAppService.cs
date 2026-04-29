using System.Threading.Tasks;
using Abp.Application.Services;
using TaskQLLH.Sessions.Dto;

namespace TaskQLLH.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
