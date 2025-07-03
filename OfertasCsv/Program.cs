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

            var mediaId = await Send.FindMediaIdAsync("ofertas.json");
            if (mediaId.HasValue)
            {
                await Send.EnviarJsonParaWordPressAsync(mediaId.Value);
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado no WordPress.");
            }
        }


    }
}
