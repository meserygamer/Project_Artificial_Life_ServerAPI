using System.Text.Json.Serialization;

namespace Project_Artificial_Life_ServerAPI.Models.ChatGPT
{
    [Serializable]
    public class ChatGPTSendMessageRequestContent
    {
        [JsonPropertyName("model")]
        public string Model { get; set; } = "gpt-3.5-turbo";

        [JsonPropertyName("messages")]
        public ICollection<ChatGPTSendMessageRequestMessageHistory> Messages { get; set; }

        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; } = null;
    }
}
