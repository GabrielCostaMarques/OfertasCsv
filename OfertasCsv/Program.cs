using OfertasCsv.Writer;

namespace OfertasCsv
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationCsv().ConfigCsv();
            var cruises = Match.MatchWriter(config).ToList();

            FilterOffers filter = new();

            var filteredByCurrency = filter.FilterGeneral(cruises, "BRL", c => c.Currency);

            Console.WriteLine($"\nFiltrados por categoria 'INTERIOR': {filteredByCurrency.Count()} cruzeiros");

            foreach (var cruise in filteredByCurrency.Take(100))
            {
                Console.WriteLine($"Cruzeiro: {cruise.ProductId} - {cruise.ProductName} ({cruise.ShipName})");
                Console.WriteLine($"Data: {cruise.DebarkDate:dd/MM/yyyy} até {cruise.EmbarkDate:dd/MM/yyyy}");
                Console.WriteLine($"Moeda: {cruise.Currency}");
                Console.WriteLine("Itinerário:");

                foreach (var item in cruise.Itinenary)
                {
                    Console.WriteLine($" Dia {item.DayOfCruise}: {item.PortName} ({item.PortCode})");
                }

                Console.WriteLine(new string('-', 50));
            }

        }
    }
}
