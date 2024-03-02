using System.Text.Json.Serialization;

namespace Project_Artificial_Life_ServerAPI.Models.ChatGPT
{
    [Serializable]
    public class ChatGPTSendMessageRequestMessageHistory
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
