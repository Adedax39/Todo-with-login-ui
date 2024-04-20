using Application.Register.Commands.CreateRegister;
using Microsoft.AspNetCore.Mvc;

namespace TODO.LIST.WITH.LOGIN.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegisterController : ApiBaseController
{

    [HttpPost]
    public async Task<IActionResult> CreateTaskAsync(CreateRegisterCommand createRegisterCommand)
    {
        // Send the command to create the task
        var createTodo = await Mediator.Send(createRegisterCommand);
    
        // Return a '201 Created' response with the newly created task
        return Ok(Created(Request.Path, createTodo));
    }




}