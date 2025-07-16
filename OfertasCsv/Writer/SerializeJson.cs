using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OfertasCsv.Entity;
using System.Globalization;

namespace OfertasCsv.Writer
{
    public static class SerializeJson
    {

        public static void GetForJson(this List<ProductOffer> offers)
        {
            var settings = new JsonSerializerSettings();

            string json = JsonConvert.SerializeObject(offers, Formatting.Indented, settings);

            Console.WriteLine("Criando Json...");

            File.WriteAllText(@"C:\Users\gmarques\Downloads\ofertasAzamara.json", json);
            Console.WriteLine("Arquivo criado");
        }
    }
}
