using CsvHelper.Configuration;
using OfertasCsv.Reader;
using System.Globalization;

namespace OfertasCsv
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationCsv().ConfigCsv();

            var connection = new ConnectionSFTP().Connection();
            var file = connection.OpenRead("./az-pricing-v3.csv");

            //var reader = new Content().ReaderContent(config, file);
            var reader = new Content().FakerReaderContent(config, file);

            foreach (var item in reader.OrderBy(o => o.CruiseFare))
            {
                Console.WriteLine(item);
            }

        }
    }
}