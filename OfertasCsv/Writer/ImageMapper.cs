using OfertasCsv.Entity;

namespace OfertasCsv.Writer
{
    public class ImageMapper
    {

       

        public List<ProductOffer> GetImageDestination(List<ProductOffer> product)
        {

          Dictionary<string, string> ImageMap = new()
        {
        { "MEDITERRANEAN", "https://manualdoagente.com.br/wp-content/uploads/2025/07/mediterran-Azamara.webp" },
        { "GRAND VOYAGE", "https://manualdoagente.com.br/wp-content/uploads/2025/07/Grand-voyage-combo.webp" },
        { "COMBO", "https://manualdoagente.com.br/wp-content/uploads/2025/07/Grand-voyage-combo.webp" },
        { "TRANSATLANTIC", "https://manualdoagente.com.br/wp-content/uploads/2025/07/Grand-voyage-combo.webp" },
        { "ALASKA", "https://manualdoagente.com.br/wp-content/uploads/2025/07/Alaska.webp" },
        { "ASIA", "https://manualdoagente.com.br/wp-content/uploads/2025/07/Asia.webp" },
        { "CARIBBEAN", "https://manualdoagente.com.br/wp-content/uploads/2025/07/Caribe.webp" },
        { "SOUTH AMERICA", "https://manualdoagente.com.br/wp-content/uploads/2025/07/south-america.webp" },
        { "WESTERN EUROPE", "https://manualdoagente.com.br/wp-content/uploads/2025/07/WESTERN-EUROPE.webp" },
        { "AUSTRALIA/NEW ZEALAND", "https://manualdoagente.com.br/wp-content/uploads/2025/07/Australia-New-Zeland.webp" },
        { "TRANSPACIFIC", "https://meusite.com/images/destinos/transpacific.jpg" },
        { "HAWAII", "https://manualdoagente.com.br/wp-content/uploads/2025/07/Hawaii.webp" },
        { "ARCTIC", "https://manualdoagente.com.br/wp-content/uploads/2025/07/Artic.webp" },
        { "AFRICA", "https://manualdoagente.com.br/wp-content/uploads/2025/07/Africa.webp" },
        { "EASTERN CARIBBEAN", "https://manualdoagente.com.br/wp-content/uploads/2025/07/EASTERN-CARIBBEAN.webp" },
        { "ATLANTIC", "https://manualdoagente.com.br/wp-content/uploads/2025/07/Atlantic.webp" },
        { "NORTHERN EUROPE", "https://manualdoagente.com.br/wp-content/uploads/2025/07/NORTHERN-EUROPE.webp" },
        { "CANADA EAST", "https://manualdoagente.com.br/wp-content/uploads/2025/07/CANADA-EAST.webp" },
        { "BALTIC", "https://manualdoagente.com.br/wp-content/uploads/2025/07/BALTIC.jpg" },
        { "WORLD CRUISE", "https://manualdoagente.com.br/wp-content/uploads/2025/07/Grand-voyage-combo.webp" },
        { "ALASKA CRUISE TOUR", "https://manualdoagente.com.br/wp-content/uploads/2025/07/ALASKA-CRUISE-TOUR.webp" },
        { "SOUTHERN CARIBBEAN", "https://manualdoagente.com.br/wp-content/uploads/2025/07/SOUTHERN-CARIBBEAN.webp" },
        { "SOUTH AFRICA", "https://manualdoagente.com.br/wp-content/uploads/2025/07/SOUTH-AFRICA.webp" },
        { "US SE COAST", "https://manualdoagente.com.br/wp-content/uploads/2025/07/US-SE-COAST.webp" },
        { "INDIAN OCEAN", "https://manualdoagente.com.br/wp-content/uploads/2025/07/INDIAN-OCEAN.webp" },
        { "CANADA", "https://manualdoagente.com.br/wp-content/uploads/2025/07/CANADA-EAST.webp" },
        { "US WEST COAST", "https://manualdoagente.com.br/wp-content/uploads/2025/07/US-WEST-COAST.webp" },
        { "NEW ENGLAND", "https://manualdoagente.com.br/wp-content/uploads/2025/07/NEW-ENGLAND.jpg" },
        { "WEST AFRICA", "https://manualdoagente.com.br/wp-content/uploads/2025/07/Africa.webp" },
        { "PANAMA CANAL", "https://manualdoagente.com.br/wp-content/uploads/2025/07/PANAMA-CANAL.webp" },
        { "NORTH ATLANTIC", "https://manualdoagente.com.br/wp-content/uploads/2025/07/Grand-voyage-combo.webp" },
        { "BERMUDA", "https://manualdoagente.com.br/wp-content/uploads/2025/07/US-SE-COAST.webp" },
        { "SOUTH PACIFIC", "https://manualdoagente.com.br/wp-content/uploads/2025/07/South-Pacific.webp" },
        };


            foreach (var item in product)
            {

                if (ImageMap.TryGetValue(item.Destination.ToUpper(), out string imageUrl))
                {
                    item.ImageBackground = imageUrl;
                }
                else
                {
                    item.ImageBackground = "https://manualdoagente.com.br/wp-content/uploads/2025/07/default-image.webp"; // Default image URL
                }
            }

            return product;
        }
    }
}
