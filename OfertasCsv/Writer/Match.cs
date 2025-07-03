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
                using Stream fileItinenary = connection.OpenRead("./az-itinerary.csv");

                var products = new Content().ReaderContent<ProductOffer>(config, fileProduct).ToList();
                var itinenaries = new Content().ReaderContent<ItinenaryOffer>(config, fileItinenary).ToList();

                Parallel.ForEach(products, item =>
                {
                    item.Itinenary = itinenaries
                        .Where(i => i.SailCode == item.ProductId)
                        .OrderBy(i => i.BerthDate)
                        .ToList();
                });

                return products.ToList();
            }

        }


    }
}
