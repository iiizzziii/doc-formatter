using coderama.api.Data;
using coderama.api.Models;
using coderama.api.Services;
using coderama.api.Services.Storage;
using Microsoft.AspNetCore.Mvc;

namespace coderama.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentController(
    // AppDbContext dbContext,
    // IDocumentStorage documentStorage,
    IDocumentService documentService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UploadDoc(
        [FromBody] DocDto body)
    {
        var newDoc = new Doc
        {
            Tags = body.Tags,
            Data = body.Data
        };

        // await dbContext.Docs.AddAsync(newDoc);
        // await dbContext.SaveChangesAsync();
        return Ok(newDoc);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDoc(int id)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDoc(int id)
    {
        var contentType = Request.Headers.Accept.FirstOrDefault();
        var format = await documentService.GetDocAsync(id, contentType);

        return Content(format, contentType);
    }
}