using OfertasCsv.Writer;

namespace OfertasCsv
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationCsv().ConfigCsv();
            var cruises = Match.MatchWriter(config)
                .FilterGeneral("BRL", c => c.Currency)
                .TakeCheaperById()
                .OrderBy(o => o.CruiseFare)
                .Take(10)
                .ToList();

            Console.WriteLine($"\nFiltrados por moeda 'BRL': {cruises.Count()} cruzeiros");
            Console.WriteLine();

            foreach (var cruise in cruises)
            {
                Console.WriteLine($"Cruzeiro: {cruise.ProductId} - {cruise.ProductName} ({cruise.ShipName})");
                Console.WriteLine($"Data: {cruise.DebarkDate:dd/MM/yyyy} até {cruise.EmbarkDate:dd/MM/yyyy}");
                Console.WriteLine($"Moeda: {cruise.Currency}");
                Console.WriteLine("Itinerário:");

                foreach (var item in cruise.Itinenary)
                {
                    Console.WriteLine($" Dia {item.DayOfCruise}: {item.PortName} ({item.PortCode})");
                }

                Console.WriteLine("Valor: R$"+cruise.CruiseFare);
                Console.WriteLine(new string('-', 50));
            }
            Console.WriteLine();
            Console.WriteLine($"\nFiltrados por mais barata por  {cruises.Count()} cruzeiros");


        }
    }
}
