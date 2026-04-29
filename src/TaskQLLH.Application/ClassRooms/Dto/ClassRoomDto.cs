using Abp.Application.Services.Dto;

namespace TaskQLLH.ClassRooms.Dto
{
    public class ClassRoomDto : EntityDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int MaxStudents { get; set; }
        public int CurrentStudents { get; set; }
        public string AcademicYear { get; set; }
        public int Semester { get; set; }
        public ClassRoomStatus Status { get; set; }
        public bool IsActive { get; set; }
    }
}