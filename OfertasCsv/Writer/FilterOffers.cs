namespace OfertasCsv.Writer
{
    public class FilterOffers : IFilter
    {
        public IEnumerable<T> FilterCategory<T>(IEnumerable<T> list, string category, Func<T, string> selector)
        {
            var normalizedCategory = category.ToUpper();
            
            try
            {
                if (!list.Any(item=>selector(item).ToUpper() == normalizedCategory))
                {
                    Console.WriteLine("Not Found Category");
                    return Enumerable.Empty<T>();
                }
                var filteredCategory = list.Where(l => selector(l) == normalizedCategory);

                return filteredCategory;
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
                return Enumerable.Empty<T>();
            }
            
        }

        public IEnumerable<T> FilterCurrency<T>(IEnumerable<T> list, string currency, Func<T, string> selector)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FilterDestination<T>(IEnumerable<T> list, string destination, Func<T, string> selector)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FilterShip<T>(IEnumerable<T> list, string ship, Func<T, string> selector)
        {
            throw new NotImplementedException();
        }
    }

}

