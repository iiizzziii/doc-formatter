using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Xml;
using coderama.api.Models;

namespace coderama.test;

[SuppressMessage("ReSharper", "ConvertToUsingDeclaration")]
public static class HelperMethods
{
    public static string SerializeToXml(Doc doc)
    {
        using (var stringWriter = new StringWriter())
        {
            var serializer = new DataContractSerializer(typeof(Doc));

            using (var writer = XmlWriter.Create(stringWriter))
            {
                serializer.WriteObject(writer, doc);
                writer.Flush();
                return stringWriter.ToString();
            }
        }
    }
    
    public static string SerializeToProtobuf(Doc doc)
    {
        using (var memoryStream = new MemoryStream())
        {
            ProtoBuf.Serializer.Serialize(memoryStream, doc);
            return Convert.ToBase64String(memoryStream.ToArray());
        }
    }

    public static string SerializeToMessagePack(Doc doc)
    {
        var bytes = MessagePack.MessagePackSerializer.Serialize(doc);
        return Convert.ToBase64String(bytes);
    }
}