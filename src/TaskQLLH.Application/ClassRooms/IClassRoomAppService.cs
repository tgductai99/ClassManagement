using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TaskQLLH.ClassRooms.Dto;

namespace TaskQLLH.ClassRooms
{
    public interface IClassRoomAppService : IApplicationService
    {
        Task<PagedResultDto<ClassRoomDto>> GetAll(GetClassRoomsInput input);
        Task<ClassRoomDto> Get(EntityDto input);
        Task<ClassRoomDto> Create(CreateClassRoomInput input);
        Task<ClassRoomDto> Update(UpdateClassRoomInput input);
        Task Delete(EntityDto input);
    }
}