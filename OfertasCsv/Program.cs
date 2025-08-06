using OfertasCsv.Infrasctructure.Configuration;
using OfertasCsv.Send;
using OfertasCsv.Writer;

namespace OfertasCsv
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ISendFile sendFile = new SendFile();

            ImageMapper image = new();

            var config = new ConfigurationCsv().ConfigCsv();
            var cruises = Match.MatchWriter(config)
                .FilterGeneral("BRL", c => c.Currency)
                .ExcludeGeneral("Alaska Cruise Tour", c => c.Destination)
                .TakeCheaperById()
                .OrderBy(o => o.CruiseFare)
                .Take(50)
                .ToList();

            var finishCruise = image.GetImageDestination(cruises);
            finishCruise.GetForJson();

            string filename = "ofertasAzamara";
            var mediaId = await sendFile.FindMediaIdAsync(filename);

            if (mediaId.HasValue)
            {
                var deletado = await sendFile.DeleteMediaAsync(mediaId.Value);
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

            var caminhoArquivo = @"./output/ofertasAzamara.json";
            await sendFile.SendJsonForWordPressAsync(caminhoArquivo);
        }


    }
}
