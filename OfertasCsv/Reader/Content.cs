using CsvHelper;
using CsvHelper.Configuration;

namespace OfertasCsv.Reader
{
    public class Content
    {
        public List<T> ReaderContent<T>(CsvConfiguration config, Stream fileStream)
        {
            using var reader = new StreamReader(fileStream);
            var csv = new CsvReader(reader, config);
            
            var list = csv.GetRecords<T>().ToList();
            return list;
        }
    }
}
