using coderama.api.Models;
using coderama.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace coderama.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentController(
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

        try
        {
            await documentService.AddDocAsync(newDoc);
        
            return Ok(newDoc);
        }
        catch (Exception e) { Console.WriteLine(e); throw; }
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDoc(
        int id,
        [FromBody] DocDto body)
    {
        var doc = new Doc
        {
            Id = id,
            Tags = body.Tags,
            Data = body.Data
        };

        try
        {
            await documentService.UpdateDocAsync(doc);

            return Ok(doc);
        }
        catch (Exception e) { Console.WriteLine(e); throw; }
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDoc(int id)
    {
        var contentType = Request.Headers.Accept.FirstOrDefault();
        if (string.IsNullOrWhiteSpace(contentType)) return BadRequest("no content type");
        
        var format = await documentService.GetDocAsync(id, contentType);
        if (string.IsNullOrWhiteSpace(format)) return NotFound("doc not found");

        return Content(format, contentType);
    }
}