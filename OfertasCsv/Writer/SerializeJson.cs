using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OfertasCsv.Entity;

namespace OfertasCsv.Writer
{
    public static class SerializeJson
    {

        public static void GetForJson(this List<ProductOffer> offers)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

            string json = JsonConvert.SerializeObject(offers, Formatting.Indented, settings);

            Console.WriteLine("Criando Json...");

            File.WriteAllText(@"C:\Users\gmarques\Downloads\ofertasAzamara.json", json);
            Console.WriteLine("Arquivo criado");
        }
    }
}
