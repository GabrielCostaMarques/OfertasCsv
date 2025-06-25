using CsvHelper;
using CsvHelper.Configuration;
using OfertasCsv.Entity;
using Renci.SshNet.Sftp;

namespace OfertasCsv.Reader
{
    public class Content
    {
        public IEnumerable<ProductOffer> ReaderContent(CsvConfiguration config, SftpFileStream fileStream)
        {
            var reader = new StreamReader(fileStream);
            var csv = new CsvReader(reader, config);

            var list = csv.GetRecords<ProductOffer>();

            return list;
        }

            //just do test
        public IEnumerable<ProductOffer> FakerReaderContent(CsvConfiguration config, SftpFileStream fileStream)
        {
            var reader = new StreamReader(fileStream);
            var csv = new CsvReader(reader, config);

            var result = new List<ProductOffer>();

            while (csv.Read())
            {
                var productOffer =csv.GetRecord<ProductOffer>(); 
                if (productOffer.Currency=="BRL")
                {
                    result.Add(productOffer);
                }

                if (result.Count >= 50) break;
            }

            return result;
        }
    }
}
