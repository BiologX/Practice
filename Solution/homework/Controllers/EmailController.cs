using homework.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace homework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : Controller
    {

        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpGet("send")] // GET /email/send
        public ActionResult<string> GetEmail()
        {
            return Ok(emailService.SendEmail());
        }

        [HttpGet("users")] // GET /email/users
        public ActionResult<object> GetUsers([FromQuery] string? search, [FromQuery] string? sortBy)
        {
            return Ok(new
            {
                Search = search ?? "Не указано",
                SortBy = sortBy ?? "Не указано",
                Message = "Параметры успешно получены"
            });
        }
    }
}
