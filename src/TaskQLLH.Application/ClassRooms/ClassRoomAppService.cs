using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using TaskQLLH.Authorization;
using TaskQLLH.ClassRooms.Dto;

namespace TaskQLLH.ClassRooms
{
    [AbpAuthorize(PermissionNames.Pages_ClassRooms)]
    public class ClassRoomAppService : TaskQLLHAppServiceBase, IClassRoomAppService
    {
        private readonly IRepository<ClassRoom> _classRoomRepository;

        public ClassRoomAppService(IRepository<ClassRoom> classRoomRepository)
        {
            _classRoomRepository = classRoomRepository;
        }

        public async Task<PagedResultDto<ClassRoomDto>> GetAll(GetClassRoomsInput input)
        {
            var query = _classRoomRepository.GetAll()
                .WhereIf(
                    !string.IsNullOrWhiteSpace(input.Filter),
                    c => c.Name.Contains(input.Filter) || c.Code.Contains(input.Filter)
                )
                .WhereIf(input.Status.HasValue, c => c.Status == input.Status.Value)
                .WhereIf(input.IsActive.HasValue, c => c.IsActive == input.IsActive.Value);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(input.Sorting ?? "Name asc")
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<ClassRoomDto>(
                totalCount,
                ObjectMapper.Map<List<ClassRoomDto>>(items)
            );
        }

        public async Task<ClassRoomDto> Get(EntityDto input)
        {
            var classRoom = await _classRoomRepository.GetAsync(input.Id);
            return ObjectMapper.Map<ClassRoomDto>(classRoom);
        }

        [AbpAuthorize(PermissionNames.Pages_ClassRooms_Create)]
        public async Task<ClassRoomDto> Create(CreateClassRoomInput input)
        {
            var classRoom = ObjectMapper.Map<ClassRoom>(input);
            await _classRoomRepository.InsertAsync(classRoom);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<ClassRoomDto>(classRoom);
        }

        [AbpAuthorize(PermissionNames.Pages_ClassRooms_Edit)]
        public async Task<ClassRoomDto> Update(UpdateClassRoomInput input)
        {
            var classRoom = await _classRoomRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, classRoom);
            return ObjectMapper.Map<ClassRoomDto>(classRoom);
        }

        [AbpAuthorize(PermissionNames.Pages_ClassRooms_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _classRoomRepository.DeleteAsync(input.Id);
        }
    }
}