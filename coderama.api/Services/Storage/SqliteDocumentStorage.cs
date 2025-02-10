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

    public async Task<int> AddAsync(Doc document)
    {
        await dbContext.Docs.AddAsync(document);

        return await dbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(Doc document)
    {
        var update = await dbContext.Docs.FirstOrDefaultAsync(d => d.Id == document.Id);
        if (update == null) return 0;

        update.Tags = document.Tags;
        update.Data = document.Data;
        
        if (!dbContext.Entry(update).Properties.Any(p => p.IsModified)) return 0;

        return await dbContext.SaveChangesAsync();
    }
}