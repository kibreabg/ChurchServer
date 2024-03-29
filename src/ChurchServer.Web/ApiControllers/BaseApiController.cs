﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ChurchServer.Web.ApiControllers
{
    /// <summary>
    /// If your API controllers will use a consistent route convention and the [ApiController] attribute (they should)
    /// then it's a good idea to define and use a common base controller class like this one.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
