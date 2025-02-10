using System.Diagnostics.CodeAnalysis;
using ProtoBuf;

namespace coderama.api.Services.Format;

[SuppressMessage("ReSharper", "ConvertToUsingDeclaration")]
public class ProtoProvider : ISerializationProvider
{
    public string ContentType => "application/x-protobuf";

    public string Serialize<T>(T model)
    {
        using (var memoryStream = new MemoryStream())
        {
            Serializer.Serialize(memoryStream, model);

            return Convert.ToBase64String(memoryStream.ToArray());
        }
    }

}