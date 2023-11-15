using MasterAuth.Core.Configurations;
using System.Net;
using System.Net.Mail;

namespace Schedule.Extensions
{
    public static class EmailExtention
    {
        public static void AddEmail(this WebApplicationBuilder builder)
        {
            var emailConfig = builder.Services.BuildServiceProvider()
                .GetRequiredService<EmailConfig>();

            services.AddFluentEmail(emailConfig.Email)
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient(emailConfig.Host, emailConfig.Port)
                {
                    Credentials = new NetworkCredential(emailConfig.Email, emailConfig.Password),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                });
        }

    }
}
