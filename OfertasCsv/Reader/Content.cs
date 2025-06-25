using CsvHelper;
using CsvHelper.Configuration;
using OfertasCsv.Entity;
using Renci.SshNet.Sftp;

namespace OfertasCsv.Reader
{
    public class Content
    {
        public IEnumerable<T> ReaderContent<T>(CsvConfiguration config, SftpFileStream fileStream)
        {
            var reader = new StreamReader(fileStream);
            var csv = new CsvReader(reader, config);

            var list = csv.GetRecords<T>();

            return list;
        }

        //just do test
        //public IEnumerable<T> FakerReaderContent<T>(CsvConfiguration config, SftpFileStream fileStream)
        //{
        //    var reader = new StreamReader(fileStream);
        //    var csv = new CsvReader(reader, config);

        //    var result = new List<T>();

        //    while (csv.Read())
        //    {
        //        var productOffer =csv.GetRecord<T>(); 
        //        if (productOffer.Currency=="BRL")
        //        {
        //            result.Add();
        //        }

        //        if (result.Count >= 50) break;
        //    }

        //    return result;
        //}
    }
}
