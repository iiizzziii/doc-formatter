using coderama.api.Models;

namespace coderama.api.Services;

public interface IDocumentService
{
    Task<string> GetDocAsync(int id, string contentType);
    Task AddDocAsync(Doc document);
    Task UpdateDocAsync(Doc document);
}