using ChurchServer.Application.Common.Mappings;
using ChurchServer.Core.Entities;

namespace ChurchServer.Application.Roles.Queries
{
    public class RoleDto : IMapFrom<Role>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
