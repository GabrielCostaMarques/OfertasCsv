using Newtonsoft.Json;
using OfertasCsv.Entity;

namespace OfertasCsv.Writer
{
    public static class SerializeJson
    {

        public static void GetForJson(this List<ProductOffer> offers)
        {
            var settings = new JsonSerializerSettings();

            string json = JsonConvert.SerializeObject(offers, Formatting.Indented, settings);

            Console.WriteLine("Criando Json...");

            var folder = "output";
            Directory.CreateDirectory(folder);
            var filePath = Path.Combine(folder, "ofertasAzamara.json");

            File.WriteAllText(filePath, json);
            Console.WriteLine("Arquivo criado");
        }
    }
}
