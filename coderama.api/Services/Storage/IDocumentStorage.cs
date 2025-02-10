using coderama.api.Models;

namespace coderama.api.Services.Storage;

public interface IDocumentStorage
{
    Task<Doc?> GetAsync(int id);
    Task<int> AddAsync(Doc document);
    Task<int> UpdateAsync(Doc document);
}