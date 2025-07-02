using CsvHelper.Configuration;
using OfertasCsv.Entity;
using OfertasCsv.Reader;

namespace OfertasCsv.Writer
{
    public class Match
    {
        public static IEnumerable<ProductOffer> MatchWriter(CsvConfiguration config)
        {
            using (var connection = new ConnectionSFTP().Connection())
            {
                using Stream fileProduct = connection.OpenRead("./az-pricing-v3.csv");
                using Stream fileItinenary = connection.OpenRead("./az-itinerary.csv");

                var products = new Content().ReaderContent<ProductOffer>(config, fileProduct);
                var itinenaries = new Content().ReaderContent<ItinenaryOffer>(config, fileItinenary);

                var all = new List<ProductOffer>();

                foreach (var item in products)
                {
                    item.Itinenary = itinenaries
                        .Where(i=>i.SailCode == item.ProductId)
                        .OrderBy(i=>i.DayOfCruise)
                        .ToList();

                    all.Add(item);
                }

                return all;


            }
        }


    }
}
