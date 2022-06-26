using JairoBrito.WebApp.Data;
using JairoBrito.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace JairoBrito.WebApp.Controllers
{
    public class MessageController : Controller
    {
        private readonly JairoBritoContext context;
        private readonly IConfiguration configuration;

        public MessageController(JairoBritoContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public IActionResult Create()
        {
            ViewBag.Sucess = null;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] MessageViewObject message, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var messageData = new MessageData
                {
                    Email = message.Email,
                    PhoneNumber = message.PhoneNumber,
                    Sender = message.Name,
                    Subject = message.Subject,
                    Text = message.Text
                };

                context.Messages.Add(messageData);

                var saved = await context.SaveChangesAsync(cancellationToken);

                var send = await SendEmail(message, cancellationToken);

                if (!(saved > 0 && send.IsSuccessStatusCode))
                {
                    ViewBag.Sucess = false;
                    ViewData["Message-Error"] = "Houve um erro ao enviar sua mensagem, por favor tente novamente em breve.";
                    return View(nameof(Create));
                }

                ModelState.Clear();
                ViewBag.Sucess = true;
                ViewData["Message-Sucess"] = "Sua mensagem foi enviada com sucesso!";
            }
            return View(nameof(Create));
        }

        private async Task<Response> SendEmail(MessageViewObject message, CancellationToken cancellationToken)
        {
            var apiKey = configuration.GetValue<string>("EmailService:ApiKey");
            var emailFrom = configuration.GetValue<string>("EmailService:EmailFrom");
            var emailTo = configuration.GetValue<string>("EmailService:EmailTo");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(emailFrom, message.Name);

            var to = new EmailAddress(emailTo, message.Name);
            var htmlContent = @$"<strong> De: {message.Email} </strong><br>
                                <strong> Telefone: {message.PhoneNumber} </strong><br>
                                <p>{message.Text}</p>
                                ";
            var msg = MailHelper.CreateSingleEmail(from, to, message.Subject, message.Text, htmlContent);
            var response = await client.SendEmailAsync(msg, cancellationToken);

            return response;
        }
    }
}