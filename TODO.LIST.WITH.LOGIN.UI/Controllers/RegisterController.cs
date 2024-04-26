using Application.Register.Commands.CreateRegister;
using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TODO.LIST.WITH.LOGIN.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ApiBaseController
    {
        private readonly TodoDbContext _dbContext;
        private readonly IEmailService _emailService;

        public RegisterController(TodoDbContext dbContext, IEmailService emailService)
        {
            _dbContext = dbContext;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync(CreateRegisterCommand createRegisterCommand)
        {
            // Send the command to create the task
            var createTodo = await Mediator.Send(createRegisterCommand);
            string randomPassword = GenerateRandomPassword();
            SavePasswordToDatabase(createRegisterCommand.EmailAddress, randomPassword);

            // Send email
            await _emailService.SendEmailAsync(createRegisterCommand.EmailAddress, "Welcome to our platform!", $"Your password: {randomPassword}");

            // Return a '201 Created' response with the newly created task
            return Ok(Created(Request.Path, createTodo));
        }

        private string GenerateRandomPassword()
        {
            // Generate a random password using any desired logic
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void SavePasswordToDatabase(string emailAddress, string password)
        {
            // Create a new record in the database to store the email address and password
            var user = new Register
            {
                EmailAddress = emailAddress,
                Password = password
            };
            _dbContext.Registers.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
