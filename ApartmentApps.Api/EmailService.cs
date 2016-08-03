using System.Threading.Tasks;
using ApartmentApps.Api.Modules;
using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ApartmentApps.Api
{
    public class EmailService : IIdentityMessageService
    {
        private readonly ILogger _logger;
        private readonly MessagingConfig _config;

        public EmailService() : this(null, null)
        {
        }

        public EmailService(ILogger logger, MessagingConfig config)
        {
            _logger = logger;
            _config = config;
        }

        public string APIKey { get; set; }
        public async Task SendAsync(IdentityMessage message)
        {

            string apiKey = "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";
            if (_config != null && !string.IsNullOrEmpty(_config.SendGridApiToken))
            {
                apiKey = _config.SendGridApiToken;
            }
            dynamic sg = new SendGridAPIClient(apiKey);

            Email from = new Email("noreply@apartmentapps.com");
            string subject = message.Subject;
            Email to = new Email(message.Destination);
            Content content = new Content("text/html", message.Body);
            Mail mail = new Mail(from, subject, to, content);

            dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
            

            //try
            //{
            //    SmtpClient client = new SmtpClient();
            //    client.UseDefaultCredentials = false;
            //    client.Credentials = new NetworkCredential("noreply@apartmentapps.com", "AptApps2016!");
            //    client.Port = 587;
            //    client.Host = "smtp.gmail.com";
            //    client.EnableSsl = true;
            //    MailAddress
            //        maFrom = new MailAddress("noreply@apartmentapps.com", "Apartment Apps", Encoding.UTF8),
            //        maTo = new MailAddress(message.Destination, string.Empty, Encoding.UTF8);
            //    MailMessage mmsg = new MailMessage(maFrom.Address, maTo.Address);
            //    mmsg.Body = message.Body;
            //    mmsg.BodyEncoding = Encoding.UTF8;
            //    mmsg.IsBodyHtml = true;
            //    mmsg.Subject = message.Subject;
            //    mmsg.SubjectEncoding = Encoding.UTF8;

            //    client.Send(mmsg);
            //}
            //catch (Exception ex)
            //{
            //    _logger?.Error($"Error sending to email {message.Destination}\r\n {ex.Message}\r\n{ex.StackTrace}");
            //}

            // Plug in your email service here to send an email.
            //return Task.FromResult(0);
        }
    }
}