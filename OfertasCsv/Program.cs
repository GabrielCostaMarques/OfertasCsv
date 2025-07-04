using OfertasCsv.Writer;

namespace OfertasCsv
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var config = new ConfigurationCsv().ConfigCsv();
            var cruises = Match.MatchWriter(config)
                .FilterGeneral("BRL", c => c.Currency)
                .TakeCheaperById()
                .OrderBy(o => o.CruiseFare)
                .Take(110)
                .ToList();

            cruises.GetForJson();

            var caminhoArquivo = @"C:\Users\gmarques\Downloads\ofertas.json";
            var mediaId = await Send.FindMediaIdAsync("ofertasAzamara");

            if (mediaId.HasValue)
            {
                var deletado = await Send.ExcluirMediaAsync(mediaId.Value);
                if (!deletado)
                {
                    Console.WriteLine("Erro ao excluir. Abortando envio.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Arquivo anterior não encontrado, prosseguindo com novo envio.");
            }

            await Send.EnviarJsonParaWordPressAsync(caminhoArquivo);
        }


    }
}
