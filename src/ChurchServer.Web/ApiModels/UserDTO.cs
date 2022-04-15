using System.ComponentModel.DataAnnotations;

namespace ChurchServer.Web.ApiModels
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class LoginRequestDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class LoginResponseDTO
    {
        public string Token { get; set; }
    }

    public class RegisterUserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
