using System.ComponentModel.DataAnnotations;

namespace coderama.api.Models;

public record DocDto
{
    [Required]
    public List<string> Tags { get; init; } = [];
    
    [Required]
    public Dictionary<string, string> Data { get; init; } = [];                           
}
