using System.Runtime.Serialization;
using ProtoBuf;

namespace coderama.api.Models;

[DataContract]
[ProtoContract]
public class Doc
{
    [DataMember]
    [ProtoMember(1)]
    public int Id { get; set; }
    
    [DataMember]
    [ProtoMember(2)]
    public List<string> Tags { get; set; } = [];
    
    [DataMember]
    [ProtoMember(3)]
    public Dictionary<string, string> Data { get; set; } = [];
}
