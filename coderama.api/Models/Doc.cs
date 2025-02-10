using System.Runtime.Serialization;

namespace coderama.api.Models;

[DataContract]
public class Doc
{
    [DataMember]
    public int Id { get; set; }
    
    [DataMember]
    public List<string> Tags { get; set; } = [];
    
    [DataMember]
    public Dictionary<string, string> Data { get; set; } = [];
}
