using ChurchServer.Application.Common.Models;
using ChurchServer.Application.Roles.Commands.AddUserToRole;
using ChurchServer.Application.Roles.Commands.CreateRole;
using ChurchServer.Application.Roles.Commands.DeleteRole;
using ChurchServer.Application.Roles.Commands.UpdateRole;
using ChurchServer.Application.Roles.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ChurchServer.Web.ApiControllers
{
    public class RolesController : BaseApiController
    {
        
        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> GetRoles()
        {
            return await Mediator.Send(new GetRolesQuery());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetRole(string id)
        {
            return await Mediator.Send(new GetRoleQuery() { Id = id });
        }
        
        [HttpPost]
        public async Task<ActionResult<string>> CreateRole(CreateRoleCommand command)
        {
            var result = await Mediator.Send(command);
            if (result.Item1.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Item1.Errors[0]);
            }
        }
        [HttpPost]
        [Route("AddUserToRole")]
        public async Task<ActionResult<Result>> AddUserToRole(AddUserToRoleCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRole(string id, UpdateRoleCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> DeleteRole(string id)
        {
            return await Mediator.Send(new DeleteRoleCommand { Id = id });
        }
        
    }
}
