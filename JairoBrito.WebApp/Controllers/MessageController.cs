using JairoBrito.WebApp.Data;
using JairoBrito.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace JairoBrito.WebApp.Controllers
{
    public class MessageController : Controller
    {
        private readonly JairoBritoContext context;

        public MessageController(JairoBritoContext context)
        {
            this.context = context;
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

                try
                {
                    context.Messages.Add(messageData);
                    await context.SaveChangesAsync(cancellationToken);

                    ModelState.Clear();
                    ViewBag.Sucess = true;
                    ViewData["Message-Sucess"] = "Sua mensagem foi enviada com sucesso!";
                }
                catch
                {
                    ViewBag.Sucess = false;
                    ViewData["Message-Error"] = "Houve um erro ao enviar sua mensagem, por favor tente novamente em breve.";
                }
            }
            return View(nameof(Create));
        }
    }
}