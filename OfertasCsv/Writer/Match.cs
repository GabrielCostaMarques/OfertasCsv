using CsvHelper.Configuration;
using OfertasCsv.Entity;
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
                var itinenaries = new Content().ReaderContent<ItinenaryOffer>(config, fileItinerary).ToList();

                Parallel.ForEach(products, item =>
                {
                    item.Itinerary = itinenaries
                        .Where(i => i.SailCode == item.ProductId)
                        .OrderBy(i => i.BerthDate)
                        .ToList();
                });

                return products.ToList();
            }

        }


    }
}
