using System.Text.Json.Serialization;

namespace OfertasCsv.Entity
{
    public class MediaItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("title")]
        public TitleData Title { get; set; }
    }
}
