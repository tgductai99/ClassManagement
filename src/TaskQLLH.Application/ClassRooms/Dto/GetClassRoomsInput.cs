using Abp.Application.Services.Dto;

namespace TaskQLLH.ClassRooms.Dto
{
    public class GetClassRoomsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public ClassRoomStatus? Status { get; set; }
    }
}   