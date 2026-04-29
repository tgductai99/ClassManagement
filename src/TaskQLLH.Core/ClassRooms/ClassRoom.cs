// ClassRoom.cs
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace TaskQLLH.ClassRooms
{
    public class ClassRoom : FullAuditedEntity
    {
        public const int MaxNameLength = 100;
        public const int MaxCodeLength = 20;
        public const int MaxDescriptionLength = 500;

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(MaxCodeLength)]
        public string Code { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public int MaxStudents { get; set; }

        public int CurrentStudents { get; set; }

        [MaxLength(20)]
        public string AcademicYear { get; set; }

        public int Semester { get; set; }

        public ClassRoomStatus Status { get; set; } = ClassRoomStatus.Active;

        public bool IsActive { get; set; } = true;
    }

    public enum ClassRoomStatus
    {
        Active = 1,
        Inactive = 2,
        Completed = 3,
        Cancelled = 4
    }
}