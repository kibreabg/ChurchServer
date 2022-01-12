using System.ComponentModel.DataAnnotations;

namespace ChurchServer.Web.ApiModels
{
    public class UserDTO
    {
    }
    public class LoginRequestDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class LoginResponseDTO
    {
        public string Token { get; set; }
    }

    public class RegisterUserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
