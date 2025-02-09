using coderama.api.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace coderama.api.Data;

public class AppDbContext(
    DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Doc> Docs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var options = JsonSerializerOptions.Default;
        
        modelBuilder.Entity<Doc>(entity => 
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Tags).IsRequired();
            entity.Property(e => e.Data).HasConversion(
                v => JsonSerializer.Serialize(v, options),
                v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, options)!);
        });
    }
}