using Application.Register.Commands.CreateRegister;
using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TODO.LIST.WITH.LOGIN.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ApiBaseController
    {
        private readonly TodoDbContext _dbContext;
        private readonly IEmailService _emailService;
        private readonly IPasswordGenerator _passwordGenerator;

        public RegisterController(TodoDbContext dbContext, IEmailService emailService,IPasswordGenerator passwordGenerator)
        {
            _dbContext = dbContext;
            _emailService = emailService;
            _passwordGenerator = passwordGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync(CreateRegisterCommand createRegisterCommand)
        {
            // Send the command to create the task
            var randomPassword = _passwordGenerator.GenerateRandomPassword();
            createRegisterCommand.Password = randomPassword;
            var createTodo = await Mediator.Send(createRegisterCommand);
            // Send email
            await _emailService.SendEmailAsync(createRegisterCommand.EmailAddress, "Your password for Todo-List!", $"Your password: {randomPassword}");
            
            //Return a '201 Created' response with the newly created task
            return Created(Request.Path, createTodo);
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(CreateRegisterCommand createRegisterCommand)
        {
            var user = await _dbContext.Registers.FirstOrDefaultAsync(u => u.UserName == createRegisterCommand.UserName);
            if (user == null)
            {
                // User not found, return 404 Not Found
                return NotFound("User not found");
            }
        
            // Check if password matches
            if (user.Password != createRegisterCommand.Password)
            {
                // Incorrect password, return 401 Unauthorized
                return Unauthorized("Incorrect password");
            }
        
            // Authentication successful, you can return additional data if needed
            return Ok("Authentication successful");
        }


    }
}
