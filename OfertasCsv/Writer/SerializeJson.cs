using OfertasCsv.Entity;
using System.Text.Json;

namespace OfertasCsv.Writer
{
    public static class SerializeJson
    {

        public static void GetForJson(this List<ProductOffer> offers)
        {
            string json = JsonSerializer.Serialize(offers);

            File.WriteAllText(@"./ofertas.json", json);
            Console.WriteLine("Arquivo criado");
        }
    }
}
