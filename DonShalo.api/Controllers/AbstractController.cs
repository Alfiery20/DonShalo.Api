using DonShalo.api.Services;
using DonShalo.Application.Common.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DonShalo.api.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        private IMediator _mediator;
        private ICurrentUser _CurrentUser;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ICurrentUser CurrentUser => HttpContext.Session.GetString("dataUser") != null ? JsonConvert.DeserializeObject<CurrentUser>(HttpContext.Session.GetString("dataUser")) : null;
    }
}
