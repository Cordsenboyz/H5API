using System.ComponentModel.DataAnnotations;

namespace H5API.Dto.User
{
    public class UserLoginDTO
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
