using AutoMapper;
using TaskQLLH.ClassRooms.Dto;

namespace TaskQLLH.ClassRooms.Dto
{
    public class ClassRoomMapProfile : Profile
    {
        public ClassRoomMapProfile()
        {
            CreateMap<ClassRoom, ClassRoomDto>();
            CreateMap<CreateClassRoomInput, ClassRoom>();
            CreateMap<UpdateClassRoomInput, ClassRoom>();
        }
    }
}