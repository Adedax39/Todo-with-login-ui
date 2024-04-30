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
            const string chars = "0123456789";
            const int length = 4; // Length of the generated password

            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    
}
public class PapercutEmailService : IEmailService
{
    private readonly string _smtpServer;
    private readonly int _smtpPort;

    public PapercutEmailService(string smtpServer, int smtpPort)
    {
        _smtpServer = smtpServer;
        _smtpPort = smtpPort;
    }

    public async Task SendEmailAsync(string toAddress, string subject, string body)
    {
        // Create the email message
        using (var mail = new MailMessage("lasathrathnayake@gmail.com", toAddress, subject, body))
        {
            // Create the SMTP client
            using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
            {
                smtpClient.EnableSsl = false;

                try
                {
                    // Send the email asynchronously
                    await smtpClient.SendMailAsync(mail);
                    Console.WriteLine("Email sent successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to send email: " + ex.Message);
                }
            }
        }
    }

}

