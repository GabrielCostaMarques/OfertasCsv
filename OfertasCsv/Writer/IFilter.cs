namespace OfertasCsv.Writer
{
    public interface IFilter
    {
        IEnumerable<T> FilterGeneral<T>(IEnumerable<T> list, string currency, Func<T, string> selector);
    }
}
