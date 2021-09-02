using System.ComponentModel.DataAnnotations;

namespace BuildingTuts.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}