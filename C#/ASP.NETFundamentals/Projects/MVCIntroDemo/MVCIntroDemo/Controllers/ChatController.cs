using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using MVCIntroDemo.Models.Chat;

namespace MVCIntroDemo.Controllers
{
    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> _chats = new List<KeyValuePair<string, string>>();

        public IActionResult Show()
        {
            if (_chats.Count < 1)
            {
                return View(new ChatViewModel());
            }

            var chatModel = new ChatViewModel()
            {
                Messages = _chats.Select(m => new MessageViewModel()
                                  {
                                      Sender = m.Key,
                                      Message = m.Value
                                  })
                                 .ToList()
            };

            return View(chatModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var newMessage = chat.CurrentMessage;

            _chats.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.Message));

            return RedirectToAction(nameof(Show));
        }
    }
}
