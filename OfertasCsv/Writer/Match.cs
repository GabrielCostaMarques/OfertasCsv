using CsvHelper.Configuration;
using OfertasCsv.Entity;
using OfertasCsv.Infrasctructure.Connection;
using OfertasCsv.Reader;

namespace OfertasCsv.Writer
{
    public class Match
    {
        public static List<ProductOffer> MatchWriter(CsvConfiguration config)
        {
            using (var connection = new ConnectionSFTP().Connection())
            {
                using Stream fileProduct = connection.OpenRead("./az-pricing-v3.csv");
                using Stream fileItinerary = connection.OpenRead("./az-itinerary.csv");

                var products = new Content().ReaderContent<ProductOffer>(config, fileProduct).ToList();
                var itinenaries = new Content().ReaderContent<ItineraryOffer>(config, fileItinerary).ToList();

                Parallel.ForEach(products, item =>
                {
                    var itineraryList = itinenaries
                        .Where(i => i.SailCode == item.ProductId)
                        .OrderBy(i => i.BerthDate)
                        .ToList();

                    item.Itinerary = itineraryList;

                    // Gera a string com os nomes dos portos separados por vírgula
                    item.ItineraryPortNames = string.Join(" - ",
                        itineraryList
                        .Where(i => i.PortName != "AT SEA")
                        .Select(i => i.PortName));
                });


                return products;
            }

        }


    }
}
