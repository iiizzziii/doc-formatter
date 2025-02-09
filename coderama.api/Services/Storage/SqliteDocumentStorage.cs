using coderama.api.Data;
using coderama.api.Models;
using Microsoft.EntityFrameworkCore;

namespace coderama.api.Services.Storage;

public class SqliteDocumentStorage(AppDbContext dbContext) : IDocumentStorage
{
    public async Task<Doc?> GetAsync(int id)
    {
        return await dbContext.Docs.FirstOrDefaultAsync(d => d.Id == id);
    }
}