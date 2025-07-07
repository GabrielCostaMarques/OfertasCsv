using System.Text.Json.Serialization;

namespace OfertasCsv.Entity
{
    public class TitleData
    {
        [JsonPropertyName("rendered")]
        public string Rendered { get; set; }
    }
}
