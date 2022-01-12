using ChurchServer.Application.Common.Mappings;
using ChurchServer.Core.Entities;

namespace ChurchServer.Application.Members.Queries
{
    public class MembersListDto : IMapFrom<Member>
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Sex { get; set; }
    }
}
