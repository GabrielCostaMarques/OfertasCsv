using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OfertasCsv
{
    public class Send
    {
        private static readonly string usuario = "";
        private static readonly string appPassword = "";
        private static readonly string baseUrl = "";

        private static HttpClient CriarHttpClient()
        {
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{appPassword}"));
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
            return client;
        }

        public static async Task<int?> FindMediaIdAsync(string fileName)
        {
            using var client = CriarHttpClient();
            var url = $"{baseUrl}/media?search={Uri.EscapeDataString(fileName)}&orderby=date&order=desc";

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Erro ao buscar mídia: {response.StatusCode}");
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            var mediaItems = JsonSerializer.Deserialize<List<MediaItem>>(json);

            var media = mediaItems?.FirstOrDefault(m => m.Title.Rendered.Contains(fileName, StringComparison.OrdinalIgnoreCase));
            return media?.Id;
        }

        public static async Task<bool> ExcluirMediaAsync(int mediaId)
        {
            using var client = CriarHttpClient();
            var url = $"{baseUrl}/media/{mediaId}?force=true";

            var response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Arquivo excluído com sucesso.");
                return true;
            }

            Console.WriteLine($"Erro ao excluir mídia: {response.StatusCode}");
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return false;
        }

        public static async Task EnviarJsonParaWordPressAsync(string caminhoArquivo, string nomeArquivo = "ofertasAzamara.json")
        {
            using var client = CriarHttpClient();
            var url = $"{baseUrl}/media";

            var conteudo = await File.ReadAllBytesAsync(caminhoArquivo);
            var content = new ByteArrayContent(conteudo);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Headers.Add("Content-Disposition", $"attachment; filename=\"{nomeArquivo}\"");

            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
                Console.WriteLine("Arquivo enviado com sucesso!");
            else
            {
                Console.WriteLine($"Erro ao enviar arquivo: {response.StatusCode}");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
    }

    public class MediaItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("title")]
        public TitleData Title { get; set; }
    }

    public class TitleData
    {
        [JsonPropertyName("rendered")]
        public string Rendered { get; set; }
    }
}
