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
    //public async Task SendEmailAsync(string email, string password)
    //{
    //    string smtpServer = "smtp.gmail.com";
    //    int smtpPort = 587;
    //    string senderEmail = "lasathrathnayake@gmail.com";
    //    string senderPassword = "Adedax91939@Batman";

    //    // Create the email message
    //    MailMessage mail = new MailMessage(new MailAddress(senderEmail), new MailAddress(email));
    //    mail.Subject = "Your Password";
    //    mail.Body = $"Your password is: {password}";

    //    // Configure SMTP client
    //    SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
    //    smtpClient.UseDefaultCredentials = false;
    //    smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
    //    smtpClient.EnableSsl = true;

    //    // Send the email
    //    await smtpClient.SendMailAsync(mail);
    //}
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

