using CsvHelper;
using CsvHelper.Configuration;

namespace OfertasCsv.Reader
{
    public class Content
    {
        public List<T> ReaderContent<T>(CsvConfiguration config, Stream fileStream)
        {

            if (fileStream == null || fileStream.Length == 0)
            {
                Console.WriteLine("O arquivo está vazio ou não foi encontrado.");
                return [];
            }
            var reader = new StreamReader(fileStream);
            var csv = new CsvReader(reader, config);

            Console.WriteLine("Lendo arquivo...");
            var list = csv.GetRecords<T>().ToList();

            return list;
        }
    }
}
