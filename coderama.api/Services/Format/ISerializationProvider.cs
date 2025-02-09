using coderama.api.Models;

namespace coderama.api.Services.Format;

public interface ISerializationProvider
{
    string ContentType { get; }
    string Serialize<T>(T model);
    // T Deserialize<T>(string data);
}