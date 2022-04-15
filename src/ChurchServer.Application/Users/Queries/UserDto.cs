using ChurchServer.Application.Common.Mappings;
using ChurchServer.Core.Entities;
using System;

namespace ChurchServer.Application.Users.Queries
{
    public class UserDto : IMapFrom<User>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class LoginResultDTO
    {
        public bool IsValid { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
