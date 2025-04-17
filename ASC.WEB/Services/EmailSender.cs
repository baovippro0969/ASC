using Microsoft.AspNetCore.Identity.UI.Services;

namespace ASC.Web.Services
{
    public class EmailSender : Microsoft.AspNetCore.Identity.UI.Services.IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _logger.LogInformation($"Sending email to {email} with subject {subject}");
            return Task.CompletedTask;
        }
    }
}
