using System.Text.Json;

namespace coderama.api.Services.Format;

public class JsonProvider : ISerializationProvider
{
    public string ContentType => "application/json";
    public string Serialize<T>(T model) => JsonSerializer.Serialize(model);
    // public T Deserialize<T>(string data) => JsonSerializer.Deserialize<T>(data)!;
}