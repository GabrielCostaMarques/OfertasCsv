using CsvHelper;
using CsvHelper.Configuration;

namespace OfertasCsv.Reader
{
    public class Content
    {
        public IEnumerable<T> ReaderContent<T>(CsvConfiguration config, Stream fileStream)
        {
            var list  = new List<T>();

            using var reader = new StreamReader(fileStream);
            var csv = new CsvReader(reader, config);
            while (csv.Read())
            {
                var item = csv.GetRecord<T>();
                list.Add(item); 
            }

            return list;
        }
    }
}
