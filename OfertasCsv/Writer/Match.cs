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
            using var connection = new ConnectionSFTP().Connection();
            var sftpFileReader = new SFTPFileReader();
            Console.WriteLine("Abrindo arquivos" );
            var fileProduct = sftpFileReader.ReadFile("./az-pricing-v3.csv", connection);
            var fileItinerary = sftpFileReader.ReadFile("./az-itinerary.csv", connection);

            var products = new Content().ReaderContent<ProductOffer>(config, fileProduct).ToList();
            var itinenaries = new Content().ReaderContent<ItineraryOffer>(config, fileItinerary).ToList();

            var processor = new ItineraryProcessor();
            processor.AttachItineraries(products, itinenaries);

            return products;
        }




    }
}
