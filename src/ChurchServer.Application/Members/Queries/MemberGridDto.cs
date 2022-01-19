using ChurchServer.Application.Common.Mappings;
using ChurchServer.Core.Entities;
using System;

namespace ChurchServer.Application.Members.Queries
{
    public class MemberGridDto : IMapFrom<Member>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Sex { get; set; }        
    }
}
