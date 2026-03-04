namespace RestCollectionView.Models
{
    using System.Text.Json.Serialization;

    public class Dog
    {
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;
    }
}
