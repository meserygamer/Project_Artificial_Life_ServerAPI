using Microsoft.AspNetCore.Mvc;
using Project_Artificial_Life_ServerAPI.Models.ChatGPT;

namespace Project_Artificial_Life_ServerAPI.Controllers
{
    [ApiController]
    [Route("chatGPT/")]
    public class ChatGPTController : Controller
    {
        [HttpPost]
        [Route("sendMessageToChatBot")]
        public ChatGPTSendMessageResponse SendMessageToChatBot(ICollection<ChatGPTSendMessageRequestMessageHistory> messageHistory)
        {
            return new ChatGPTSendMessageResponse();
        }
    }
}
