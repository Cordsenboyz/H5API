using System.ComponentModel.DataAnnotations;

namespace H5API.Dto.User
{
    public class UserRegisterDTO
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
