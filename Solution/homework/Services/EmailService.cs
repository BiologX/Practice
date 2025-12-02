using homework.Abstractions;

namespace homework.Services
{
    public class EmailService : IEmailService
    {
        public string SendEmail()
        {
            return "example@mail.com";
        }
    }
}
