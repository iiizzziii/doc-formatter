namespace coderama.api.Services;

public interface IDocumentService
{
    Task<string> GetDocAsync(int id, string contentType);
}