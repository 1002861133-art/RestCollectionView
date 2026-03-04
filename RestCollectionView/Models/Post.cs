namespace RestCollectionView.Models
{
    using System.Text.Json.Serialization;

    public class Post
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; } = 0;

        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("body")]
        public string Body { get; set; } = string.Empty;
    } 
}
