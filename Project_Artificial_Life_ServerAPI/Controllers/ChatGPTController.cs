using Microsoft.AspNetCore.Mvc;
using Project_Artificial_Life_ServerAPI.Models.ChatGPT;
using System.Net;
using System.Text.Json;

namespace Project_Artificial_Life_ServerAPI.Controllers
{
    [ApiController]
    [Route("chatGPT/")]
    public class ChatGPTController : Controller
    {
        public ChatGPTController(IConfiguration configuration, IHttpClientFactory httpClientFactory) 
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiKey = configuration["Config:ChatGPT_API_KEY"];
        }


        /// <summary>
        /// Адрес Endpoint ChatGPT API для получения ответа бота на сообщение пользователя 
        /// </summary>
        public const string CHATGPT_CHAT_REQUEST_URL = "https://api.openai.com/v1/chat/completions";


        [HttpPost]
        [Route("sendMessageToChatBot")]
        public async Task<ChatGPTSendMessageResponse?> SendMessageToChatBot(ChatGPTSendMessageRequest chatGPTMessage)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, CHATGPT_CHAT_REQUEST_URL);
            request.Headers.Add("Authorization", "Bearer " + _apiKey);
            request.Content = JsonContent.Create(chatGPTMessage);
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.StatusCode != HttpStatusCode.OK) return null;
            var responseContentString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ChatGPTSendMessageResponse>(responseContentString);
        }


        /// <summary>
        /// http клиент для отправки запроса к ChatGPT API
        /// </summary>
        private HttpClient _httpClient;

        /// <summary>
        /// Ключ для ChatGPT 
        /// </summary>
        private string _apiKey;
    }
}
