using System.Text.Json.Serialization;

namespace WebApiNative.Infraestructure.Exceptions
{
    public class ExceptionRequestDto
    {
        public ExceptionRequestDto()
        {
            this.Errors = new Dictionary<string, string[]>();
        }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("traceId")]
        public string TraceId { get; set; }

        [JsonPropertyName("errors")]
        public Dictionary<string, string[]> Errors { get; set; }

        [JsonPropertyName("detail")]
        public object Detail { get; set; }
    }
}
