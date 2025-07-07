namespace OfertasCsv.Send
{
    public interface ISendFile
    {
        Task<int?> FindMediaIdAsync(string filename);
        Task<bool> DeleteMediaAsync(int mediaId);
        Task SendJsonForWordPressAsync(string caminhoArquivo, string nomeArquivo = "ofertasAzamara.json");
    }
}