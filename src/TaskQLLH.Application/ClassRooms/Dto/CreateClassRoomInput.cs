using System.ComponentModel.DataAnnotations;

namespace TaskQLLH.ClassRooms.Dto
{
    public class CreateClassRoomInput
    {
        [Required]
        [MaxLength(ClassRoom.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ClassRoom.MaxCodeLength)]
        public string Code { get; set; }

        [MaxLength(ClassRoom.MaxDescriptionLength)]
        public string Description { get; set; }

        public int MaxStudents { get; set; }

        [MaxLength(20)]
        public string AcademicYear { get; set; }

        public int Semester { get; set; }

        public ClassRoomStatus Status { get; set; } = ClassRoomStatus.Active;

        public bool IsActive { get; set; } = true;
    }
}