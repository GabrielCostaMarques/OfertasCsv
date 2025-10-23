using CsvHelper.Configuration;
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

            var config = ConfigurationCsv.ConfigCsv();
            var cruises = Match.MatchWriter(config)
                .FilterGeneral("BRL", c => c.Currency)
                .ExcludeGeneral("Alaska Cruise Tour", c => c.Destination)
                .TakeCheaperById()
                .OrderBy(o => o.CruiseFare)
                .Take(100)
                .ToList();

            var finishCruise = image.GetImageDestination(cruises);
            // Replace this line:
            finishCruise.GetForJson();


            // With this line:

            var caminhoArquivo = @"C:\Users\gmarques\Downloads\ofertasAzamara.json";
            string filename = "ofertasAzamara";
            var mediaId = await sendFile.FindMediaIdAsync(filename);



            string caminho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "produtos.csv");
            CsvSerialize.SaveAsCsv(finishCruise, caminho);

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

            await sendFile.SendJsonForWordPressAsync(caminhoArquivo);
        }


    }
}
