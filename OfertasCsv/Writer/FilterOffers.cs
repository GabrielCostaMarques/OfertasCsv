namespace OfertasCsv.Writer
{
    public class FilterOffers : IFilter
    {
        public IEnumerable<T> FilterGeneral<T>(IEnumerable<T> list, string obj, Func<T, string> selector)
        {
            try
            {
                if (!list.Any(item => selector(item).ToUpper() == obj))
                {
                    Console.WriteLine("Not Found " + obj);
                    return Enumerable.Empty<T>();
                }

                var filteredCategory = list.Where(l => selector(l).ToUpper() == obj);

                return filteredCategory;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<T>();
            }

        }
    }

}

