using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Xml;

namespace coderama.api.Services.Format;

[SuppressMessage("ReSharper", "ConvertToUsingDeclaration")]
public class XmlProvider : ISerializationProvider
{
    public string ContentType => "application/xml";

    public string Serialize<T>(T model)
    {
        var xmlSerializer = new DataContractSerializer(typeof(T));
        
        using (var stringWriter = new StringWriter())
        {
            using (var xmlWriter = new XmlTextWriter(stringWriter))
            {
                xmlWriter.Formatting = Formatting.Indented;
                xmlSerializer.WriteObject(xmlWriter, model);
            }
            
            return stringWriter.ToString();
        }
    }
}