using CsvHelper.Configuration;
using OfertasCsv.Entity;
using OfertasCsv.Reader;
using OfertasCsv.Writer;
using System.Globalization;

namespace OfertasCsv
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationCsv().ConfigCsv();

            var connection = new ConnectionSFTP().Connection();
            var fileProduct = connection.OpenRead("./az-pricing-v3.csv");
            var fileItinenary = connection.OpenRead("./az-itinerary.csv");

            var itinenaries = new Content().ReaderContent<ItinenaryOffer>(config, fileItinenary);
            var products = new Content().ReaderContent<ProductOffer>(config, fileProduct);

            FilterOffers filter = new();
            var result = filter.FilterCategory(products, "INTER", c =>c.CategoryName);


            foreach (var item in result.Take(100))
            {
                Console.WriteLine(item);
            }

        }
    }
}