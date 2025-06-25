namespace OfertasCsv.Writer
{
    public interface IFilter
    {
        IEnumerable<T> FilterCurrency<T>(IEnumerable<T> list, string currency, Func<T, string> selector);
        IEnumerable<T> FilterShip<T>(IEnumerable<T> list, string ship, Func<T, string> selector);
        IEnumerable<T> FilterCategory<T>(IEnumerable<T> list, string category, Func<T, string> selector);
        IEnumerable<T> FilterDestination<T>(IEnumerable<T> list, string destination, Func<T, string> selector);
    }
}
