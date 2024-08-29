using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Threading.Tasks;
using EK.Business.Dto;
using EK.Business.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace EK.Business.Services
{
    public class MailService : IMailService
    {
        private readonly EmailConfigurationDto _emailConfiguration;

        public MailService(IOptions<EmailConfigurationDto> emailConfiguration)
        {
            _emailConfiguration = emailConfiguration.Value
                ?? throw new ArgumentNullException(nameof(emailConfiguration), "Email configuration cannot be null");
        }
         
        public async Task SendPasswordResetEmailAsync(string email, string resetLink)
        {
            var smtpClient = new SmtpClient();
            try
            {
                //SMTP Client Oluşturma ve Bağlantı Kurma
                smtpClient.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                //SMTP Sunucusuna Bağlanma
                await smtpClient.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, _emailConfiguration.EnableSsl);
                smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
                await smtpClient.AuthenticateAsync(_emailConfiguration.Username, _emailConfiguration.Password);
                //E-posta Mesajını Oluşturma
                var from = new MailboxAddress(_emailConfiguration.From, _emailConfiguration.From);
                var to = new MailboxAddress(email, email);
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(from);
                emailMessage.To.Add(to);
                emailMessage.Subject = "Şifre Yenileme İsteği";

            
                var emailBody = $"Şifrenizi sıfırlamak için <a href='{resetLink}'>buraya</a> tıklayın.";

                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = emailBody
                };

                await smtpClient.SendAsync(emailMessage);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error sending email: {ex.Message}", ex);
            }
            finally
            {
                await smtpClient.DisconnectAsync(true);
                smtpClient.Dispose();
            }
        }
    }
}
