using CsvHelper.Configuration;
using System.Globalization;

namespace OfertasCsv.Infrasctructure.Configuration
{
    public class ConfigurationCsv
    {
        public static CsvConfiguration ConfigCsv()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true,

            };

            return config;
        }
    }
}
