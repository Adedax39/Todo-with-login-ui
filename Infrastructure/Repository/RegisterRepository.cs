using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using System.Net.Mail;
using System.Net;

namespace Infrastructure.Repository;

public class RegisterRepository : IRegisterRepository
{
    private readonly TodoDbContext _todoDbContext;

    public RegisterRepository(TodoDbContext todoDbContext)
    {
        _todoDbContext = todoDbContext;
    }

    public async Task<Register> CreateAccAsync(Register register)
    {
        await _todoDbContext.Registers.AddAsync(register);
        await _todoDbContext.SaveChangesAsync();
        return register;
    }
}
public class PasswordRepository : IPasswordGenerator
{ 
        public string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+=-";
            const int length = 4; // Length of the generated password

            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    
}
public class EmailService : IEmailService
{
    public async Task SendEmailAsync(string email, string password)
    {
        string smtpServer = "smtp.gmail.com";
        int smtpPort = 587;
        string senderEmail = "lasathrathnayake@gmail.com";
        string senderPassword = "Adedax91939@Batman";

        // Create the email message
        MailMessage mail = new MailMessage(new MailAddress(senderEmail), new MailAddress(email));
        mail.Subject = "Your Password";
        mail.Body = $"Your password is: {password}";

        // Configure SMTP client
        SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
        smtpClient.EnableSsl = true;

        // Send the email
        await smtpClient.SendMailAsync(mail);
    }
}

