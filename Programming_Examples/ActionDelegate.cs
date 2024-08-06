using Programming_Examples.Services;

namespace Programming_Examples
{
    public static class ActionDelegate
    {
        public static void SendNotification()
        {
            string recipientEmail = "mir.javid3822@gmail.com";
            string recipientPhone = "7889933902";
            string message = "Your insurance policy has been updated.";

            // Create Action delegates for email and SMS notifications
            Action<string, string> emailNotification = SendEmailNotification;
            Action<string, string> smsNotification = SendSmsNotification;

            // Send notifications using the Action delegates
            Notify(recipientEmail, message, emailNotification);
            Notify(recipientPhone, message, smsNotification);
        }
        private static void SendEmailNotification(string recipient, string message)
        {
            Console.WriteLine($"Sending Email to {recipient}: {message}");
            // SMTP configuration
            //string smtpServer = "smtp.gmail.com";
            string smtpServer = "smtp.mail.yahoo.com";
            int smtpPort = 587;
            string smtpUser = "mailforemailtest@yahoo.com";
            string smtpPass = "mailforemailtest@123";

            // Email details
            string from = "mailforemailtest@yahoo.com";
            string to = recipient;
            string subject = "Test Email";
            string body = $"<h1> Sending Mail To {recipient} </h1><p> {message} </p>";

            var emailService = new EmailService(smtpServer, smtpPort, smtpUser, smtpPass);
            emailService.SendEmail(from, to, subject, body);
        }

        // Define a method to send an SMS notification
        private static void SendSmsNotification(string recipient, string message)
        {
            Console.WriteLine($"Sending SMS to {recipient}: {message}");
            // logic to send an SMS
        }

        // Method to trigger a notification using an Action delegate
        private static void Notify(string recipient, string message, Action<string, string> notificationMethod)
        {
            notificationMethod(recipient, message);
        }
    }
}
