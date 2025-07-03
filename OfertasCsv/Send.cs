using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OfertasCsv
{
    public class Send
    {
        public static async Task EnviarJsonParaWordPressAsync(int mediaId)
        {
            var caminhoArquivo = @"C:\Users\gmarques\Downloads\ofertas.json";
            var url = $"https://manualdoagente.com.br/wp-json/wp/v2/media/{mediaId}";

            var usuario = "Gabriel Marques";
            var appPassword = "p2DhLNweu5Ct4m1GlTRiAAX6";

            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{appPassword}"));

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

            var conteudo = await File.ReadAllBytesAsync(caminhoArquivo);
            var content = new ByteArrayContent(conteudo);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Headers.Add("Content-Disposition", "attachment; filename=\"ofertas.json\"");

            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Arquivo atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine($"Erro: {response.StatusCode}");
                var detalhes = await response.Content.ReadAsStringAsync();
                Console.WriteLine(detalhes);
            }
        }

        public static async Task<int?> FindMediaIdAsync(string fileName)
        {
            var url = "https://manualdoagente.com.br/wp-json/wp/v2/media?search=" + Uri.EscapeDataString(fileName);
            var usuario = "Gabriel Marques";
            var appPassword = "p2DhLNweu5Ct4m1GlTRiAAX6";

            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{appPassword}"));

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Erro ao buscar mídia: {response.StatusCode}");
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            var mediaItems = JsonSerializer.Deserialize<List<MediaItem>>(json);

            foreach (var item in mediaItems)
            {
                Console.WriteLine($"Título: {item.Title?.Rendered}");
            }

            var media = mediaItems?.FirstOrDefault(m => m.Title.Rendered.Contains(fileName, StringComparison.OrdinalIgnoreCase));
            return media?.Id;
        }
    }

    // Classes auxiliares DEVEM ficar fora do método
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
