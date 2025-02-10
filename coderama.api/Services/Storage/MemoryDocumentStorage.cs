using coderama.api.Models;

namespace coderama.api.Services.Storage;

public class MemoryDocumentStorage(Dictionary<int, Doc> storage) : IDocumentStorage
{
    private static int _id;

    public async Task<Doc?> GetAsync(int id)
    {
        storage.TryGetValue(id, out var doc);

        return await Task.FromResult(doc);
    }

    public async Task<int> AddAsync(Doc document)
    {
        document.Id = _id++;
        storage[document.Id] = document;

        return await Task.FromResult(1);
    }

    public async Task<int> UpdateAsync(Doc document)
    {
        storage[document.Id] = document; //add comparison

        return await Task.FromResult(1);
    }
}
