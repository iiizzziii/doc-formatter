using coderama.api.Services.Format;
using coderama.api.Services.Storage;

namespace coderama.api.Services;

public class DocumentService(
    IDocumentStorage storage,
    SerializationProviderFactory serializationProviderFactory) : IDocumentService
{
    public async Task<string> GetDocAsync(int id, string contentType)
    {
        var doc = await storage.GetAsync(id);
        if (doc == null) throw new KeyNotFoundException($"{id} not found");
        
        var serializationProvider = serializationProviderFactory.GetProvider(contentType);
        return serializationProvider.Serialize(doc);
    }
}