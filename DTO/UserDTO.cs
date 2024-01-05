using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.DTO
{
    public class UserDTO
    {
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}