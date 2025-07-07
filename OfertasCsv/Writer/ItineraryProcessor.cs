using OfertasCsv.Entity;

namespace OfertasCsv.Writer
{
    public class ItineraryProcessor
    {
        public void AttachItineraries(List<ProductOffer> productOfferList, List<ItineraryOffer> itineraryOffersList)
        {
            Parallel.ForEach(productOfferList, item =>
            {
                var itineraryList = itineraryOffersList
                    .Where(i => i.SailCode == item.ProductId)
                    .OrderBy(i => i.BerthDate)
                    .ToList();

                item.Itinerary = itineraryList;

                item.ItineraryPortNames = string.Join(" \u2022 ",
                    itineraryList
                    .Where(i => i.PortName != "AT SEA")
                    .Select(i => i.PortName));

                item.EmbarkPortName = itineraryList
                    .FirstOrDefault(i => i.PortCode == item.EmbarkPortCode)?.PortName ?? string.Empty;
            });

        }
    }
}
