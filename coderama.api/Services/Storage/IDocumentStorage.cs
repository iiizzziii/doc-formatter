using coderama.api.Models;

namespace coderama.api.Services.Storage;

public interface IDocumentStorage
{
    Task<Doc?> GetAsync(int id);
}