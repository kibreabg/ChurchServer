using ChurchServer.Application.Services.Commands.CreateService;
using ChurchServer.Application.Services.Commands.DeleteService;
using ChurchServer.Application.Services.Commands.UpdateService;
using ChurchServer.Application.Services.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChurchServer.Web.ApiControllers
{
    public class ServicesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<ServiceDto>>> GetServices()
        {
            return await Mediator.Send(new GetServicesQuery());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDto>> GetService(int id)
        {
            return await Mediator.Send(new GetServiceQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateService(CreateServiceCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateService(int id, UpdateServiceCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteService(int id)
        {
            await Mediator.Send(new DeleteServiceCommand { Id = id });

            return NoContent();
        }
    }
}
