using ChurchServer.Application.Common.Mappings;
using ChurchServer.Core.Entities;

namespace ChurchServer.Application.Services.Queries
{
    public class ServiceDto : IMapFrom<Service>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
