using ChurchServer.Application.Members.Commands.CreateMember;
using ChurchServer.Application.Members.Commands.DeleteMember;
using ChurchServer.Application.Members.Commands.UpdateMember;
using ChurchServer.Application.Members.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChurchServer.Web.ApiControllers
{
    [Authorize]
    public class MembersController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<MemberGridDto>>> GetMembers()
        {
            return await Mediator.Send(new GetMembersQuery());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetMember(int id)
        {
            return await Mediator.Send(new GetMemberQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateMemberCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateMemberCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteMemberCommand { Id = id });

            return NoContent();
        }
    }
}
