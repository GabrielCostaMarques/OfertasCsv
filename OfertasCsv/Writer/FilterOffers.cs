using OfertasCsv.Entity;

namespace OfertasCsv.Writer
{
    public static class FilterOffers
    {
        public static List<T> FilterGeneral<T>(this List<T> list, string obj, Func<T, string> selector)
        {
            try
            {
                if (!list.Exists(item => selector(item).ToUpper() == obj))
                {
                    Console.WriteLine("Not Found " + obj);
                    return new List<T>();
                }

                var filteredCategory = list.Where(l => selector(l).ToUpper() == obj).ToList();

                return filteredCategory;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<T>();
            }
        }

        public static List<T> TakeCheaperById<T>(this List<T> list) where T :ProductOffer
        {
            var cheaplist = list
            .GroupBy(p=>p.ProductId)
            .Select(p=>p.OrderBy(x=>x.CruiseFare).First())
            .ToList();

            return cheaplist;
        }

    }

}

