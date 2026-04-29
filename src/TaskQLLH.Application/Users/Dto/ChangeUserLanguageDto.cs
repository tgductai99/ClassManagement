using System.ComponentModel.DataAnnotations;

namespace TaskQLLH.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}