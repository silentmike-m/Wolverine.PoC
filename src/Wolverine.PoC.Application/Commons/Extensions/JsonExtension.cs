namespace Wolverine.PoC.Application.Commons.Extensions;

using System.Text.Json;

public static class JsonExtensions
{
    public static T To<T>(this string source)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        return JsonSerializer.Deserialize<T>(source, options)
               ?? throw new NullReferenceException();
    }

    public static string ToJson<T>(this T source)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        return JsonSerializer.Serialize(source, options);
    }
}
