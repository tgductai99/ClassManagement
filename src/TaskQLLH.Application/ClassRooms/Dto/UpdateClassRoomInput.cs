using Abp.Application.Services.Dto;

namespace TaskQLLH.ClassRooms.Dto
{
    public class UpdateClassRoomInput : CreateClassRoomInput, IEntityDto
    {
        public int Id { get; set; }
    }
}