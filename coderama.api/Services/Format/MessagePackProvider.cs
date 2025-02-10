using MessagePack;

namespace coderama.api.Services.Format;

public class MessagePackProvider : ISerializationProvider
{
    public string ContentType => "application/x-msgpack";

    public string Serialize<T>(T model)
    {
        var bytes = MessagePackSerializer.Serialize(model);

        return Convert.ToBase64String(bytes);
    }
}