using System.Text;
using System.Reflection;

public static class CsvSerialize
{
    public static void SaveAsCsv<T>(List<T> data, string filePath)
    {
        if (data == null || !data.Any())
            throw new ArgumentException("A lista está vazia ou nula.");

        var sb = new StringBuilder();
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // Cabeçalho
        sb.AppendLine(string.Join(",", properties.Select(p => p.Name)));

        // Valores
        foreach (var item in data)
        {
            var values = properties.Select(p =>
            {
                var value = p.GetValue(item, null)?.ToString() ?? "";
                return EscapeCsvValue(value);
            });

            sb.AppendLine(string.Join(",", values));
        }

        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
    }

    private static string EscapeCsvValue(string value)
    {
        if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
        {
            value = value.Replace("\"", "\"\"");
            return $"\"{value}\"";
        }
        return value;
    }
}
