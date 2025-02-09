namespace coderama.api.Services.Format;

public class SerializationProviderFactory(IEnumerable<ISerializationProvider> providers)
{
    public ISerializationProvider GetProvider(string contentType)
    {
        return providers.FirstOrDefault(p => p.ContentType == contentType)
               ??
        throw new NotSupportedException($"content type {contentType} not supported...yet");
    }
}