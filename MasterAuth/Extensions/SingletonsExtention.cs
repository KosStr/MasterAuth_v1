using MasterAuth.Core.Configurations;

namespace MasterAuth.Extensions
{
    public static class SingletonsExtention
    {
        public static void AddSingletons(this WebApplicationBuilder builder)
        {
            var jwtSettings = new JwtSettings();
            builder.Configuration.GetSection("JwtSettings").Bind(jwtSettings);
            builder.Services.AddSingleton(jwtSettings);

            var emailSettings = new EmailConfig();
            builder.Configuration.GetSection("EmailSettings").Bind(emailSettings);
            builder.Services.AddSingleton(emailSettings);
        }
    }
}
