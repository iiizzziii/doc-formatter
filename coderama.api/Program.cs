using coderama.api.Data;
using coderama.api.Services;
using coderama.api.Services.Format;
using coderama.api.Services.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<IDocumentStorage, SqliteDocumentStorage>();
builder.Services.AddScoped<ISerializationProvider, JsonProvider>();
builder.Services.AddScoped<ISerializationProvider, XmlProvider>();
builder.Services.AddScoped<SerializationProviderFactory>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();