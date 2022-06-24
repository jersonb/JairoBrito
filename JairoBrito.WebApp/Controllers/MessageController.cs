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
            ViewBag.Sucess = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] MessageViewObject message)
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
                await context.SaveChangesAsync();

                ViewBag.Sucess = true;
                ModelState.Clear();
            }
            return View(nameof(Create));
        }
    }
}