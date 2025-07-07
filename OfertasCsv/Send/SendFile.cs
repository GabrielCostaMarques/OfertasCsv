using OfertasCsv.Entity;
using OfertasCsv.Infrasctructure.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

namespace OfertasCsv.Send
{
    public class SendFile : ISendFile
    {
        private static readonly string baseUrl = "https://manualdoagente.com.br/wp-json/wp/v2";
        public async Task<int?> FindMediaIdAsync(string fileName)
        {
            using var client = new ConfigHttpClient().Create();

            Console.WriteLine($"Buscando ID da mídia para o arquivo: {fileName}");
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

        public async Task<bool> DeleteMediaAsync(int mediaId)
        {
            using var client = new ConfigHttpClient().Create();
            var url = $"{baseUrl}/media/{mediaId}?force=true";

            var response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Arquivo antigo excluído do Wordpress com sucesso!");
                return true;
            }

            Console.WriteLine($"Erro ao excluir mídia: {response.StatusCode}");
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return false;
        }

        public async Task SendJsonForWordPressAsync(string fileWay, string fileName)
        {
            using var client = new ConfigHttpClient().Create();
            var url = $"{baseUrl}/media";

            var content = await File.ReadAllBytesAsync(fileWay);
            var byteContent = new ByteArrayContent(content);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            byteContent.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");

            var response = await client.PostAsync(url, byteContent);

            if (response.IsSuccessStatusCode)
                Console.WriteLine("Novo arquivo enviado com sucesso!");
            else
            {
                Console.WriteLine($"Erro ao enviar arquivo: {response.StatusCode}");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
