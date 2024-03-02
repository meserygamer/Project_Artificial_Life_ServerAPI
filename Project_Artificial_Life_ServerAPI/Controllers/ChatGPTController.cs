using Microsoft.AspNetCore.Mvc;

namespace Project_Artificial_Life_ServerAPI.Controllers
{
    [ApiController]
    [Route("chatGPT/")]
    public class ChatGPTController : Controller
    {
        [HttpPost]
        [Route("sendMessageToChatBot")]
        public IActionResult SendMessageToChatBot()
        {
            return View();
        }
    }
}
