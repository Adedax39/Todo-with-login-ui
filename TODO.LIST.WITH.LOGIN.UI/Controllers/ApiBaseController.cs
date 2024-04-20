using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TODO.LIST.WITH.LOGIN.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class ApiBaseController : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}