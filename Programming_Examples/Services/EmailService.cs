using MailKit.Net.Smtp;
using MimeKit;
using System.Net.Mail;
using System.Net;

namespace Programming_Examples.Services
{

    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;

        public EmailService(string smtpServer, int smtpPort, string smtpUser, string smtpPass)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUser = smtpUser;
            _smtpPass = smtpPass;
        }

        public void SendEmail(string from, string to, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sender Name", from));
            message.To.Add(new MailboxAddress("Recipient Name", to));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = body
            };
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    // For demo purposes, accept all SSL certificates (not recommended in production)
                   // client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate(_smtpUser, _smtpPass);

                    client.Send(message);
                    client.Disconnect(true);
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            Console.WriteLine("Email sent successfully!");
        }

        public void SendEmailSMTP(string from, string to, string subject, string body)
        {
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(from);
            mailMessage.To.Add(to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true; // Set to true if the body is HTML

            using (var smtpClient = new System.Net.Mail.SmtpClient(_smtpServer, _smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(_smtpUser, _smtpPass);
                smtpClient.EnableSsl = true; // Enable SSL for secure connection
                smtpClient.UseDefaultCredentials = false;

                try
                {
                    smtpClient.Send(mailMessage);
                    Console.WriteLine("Email sent successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
            }
        }
    }
}
