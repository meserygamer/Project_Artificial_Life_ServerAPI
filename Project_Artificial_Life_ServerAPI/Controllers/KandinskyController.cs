using Microsoft.AspNetCore.Mvc;
using Project_Artificial_Life_ServerAPI.Models.Kandinsky;
using System.Text.Json;
using System;

namespace Project_Artificial_Life_ServerAPI.Controllers
{
    [ApiController]
    [Route("Kandinsky/")]
    public class KandinskyController : Controller
    {
        
        public KandinskyController(IConfiguration configuration, IHttpClientFactory httpClientFactory) 
        {
            _httpClient = httpClientFactory.CreateClient();
            _xKey = configuration["Config:X-Key"];
            _SecretKey = configuration["Config:X-Secret"];
        }


        /// <summary>
        /// Адрес Endpoint ChatGPT API для получения ответа бота на сообщение пользователя 
        /// </summary>
        public const string KANDINSKY_REQUEST_URL = "https://api-key.fusionbrain.ai/";


        [HttpPost]
        [Route("SendRequestToServer")]
        public async Task<KandinskyImageMessage?> SendGenerateImageRequestToServer(KandinskySendRequestOnGeneratingParams messageParams) 
        {
            var HttpRequest = new HttpRequestMessage(HttpMethod.Post, KANDINSKY_REQUEST_URL + "key/api/v1/text2image/run");
            SetHttpRequestMessageHeaders(HttpRequest, _xKey, _SecretKey);
            var content = new MultipartFormDataContent();
            content.Add(JsonContent.Create(messageParams.messageParam), "params");
            content.Add(new StringContent(messageParams.modelID.ToString()), "model_id");
            HttpRequest.Content = content;
            HttpResponseMessage response = await _httpClient.SendAsync(HttpRequest);
            string ResponseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<KandinskyImageMessage>(ResponseString);
        }


        /// <summary>
        /// http клиент для отправки запроса
        /// </summary>
        private HttpClient _httpClient;

        /// <summary>
        /// Ключ для Kandinsky
        /// </summary>
        private string _xKey;
        /// <summary>
        /// Секретный ключ для Kandinsky
        /// </summary>
        private string _SecretKey;


        private HttpRequestMessage SetHttpRequestMessageHeaders(HttpRequestMessage request, string x_key, string x_secret)
        {
            request.Headers.Add("X-Key", "Key " + x_key);
            request.Headers.Add("X-Secret", "Secret " + x_secret);
            return request;
        }

    }
}
