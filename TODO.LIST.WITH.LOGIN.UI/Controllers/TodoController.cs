using Application.Todo.Commands.CreateTodo;
using Application.Todo.Commands.DeleteTodo;
using Application.Todo.Commands.UpdateTodo;
using Application.Todo.Queries.GetTodoById;
using Application.Todo.Queries.GetTodos;
using Microsoft.AspNetCore.Mvc;

namespace TODO.LIST.WITH.LOGIN.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllTaskAsync()
    {
        var todos = await Mediator.Send(new GetTodoQuery());
        return Ok(todos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskByIdAsync(int id)
    {
        var todos = await Mediator.Send(new GetTodoByIdQuery { TodoId = id });
        return Ok(todos);
    }

    [HttpPost]
    public async Task<ActionResult<TodoVm>> CreateTodo([FromBody] CreateTodoCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTaskAsync(int id, UpdateTodoCommand updateTodoCommand)
    {
        if (id != updateTodoCommand.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(updateTodoCommand);
        var updatedList = await Mediator.Send(new GetTodoQuery());

        return Ok(updatedList);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteTodoCommand() { TodoId = id }); 
        var updatedList = await Mediator.Send(new GetTodoQuery());
        return Ok(updatedList);
    }


}