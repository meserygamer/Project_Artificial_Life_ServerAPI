
using System.Text.Json.Serialization;

namespace Project_Artificial_Life_ServerAPI.Models.ChatGPT
{
    [Serializable]
    public class ChatGPTSendMessageResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("object")]
        public string Object { get; set; }

        [JsonPropertyName("created")]
        public int Created { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("system_fingerprint")]
        public string System_fingerprint { get; set; }

        [JsonPropertyName("choices")]
        public ICollection<ChatGPTSendMessageResponseChoice> Choices { get; set; }

        [JsonPropertyName("usage")]
        public ChatGPTSendMessageResponseUsage Usage { get; set; }
    }

    [Serializable]
    public class ChatGPTSendMessageResponseUsage
    {
        [JsonPropertyName("prompt_tokens")]
        public int Prompt_tokens { get; set; }
        [JsonPropertyName("completion_tokens")]
        public int Completion_tokens { get; set; }
        [JsonPropertyName("total_tokens")]
        public int Total_tokens { get; set; }
    }

    [Serializable]
    public class ChatGPTSendMessageResponseChoice
    {
        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("message")]
        public ChatGPTSendMessageRequestMessageHistory Message { get; set; }

        [JsonPropertyName("logprobs")]
        public object Logprobs { get; set; }

        [JsonPropertyName("finish_reason")]
        public string Finish_reason { get; set; }
    }
}
