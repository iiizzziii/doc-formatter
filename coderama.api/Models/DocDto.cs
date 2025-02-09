namespace coderama.api.Models;

public record DocDto
{
    public List<string> Tags { get; init; } = [];
    public Dictionary<string, string> Data { get; set; } = [];                           
}
