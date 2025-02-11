using System.Text.Json;
using coderama.api.Models;
using coderama.api.Services;
using coderama.api.Services.Format;
using coderama.api.Services.Storage;
using NSubstitute;

namespace coderama.test;

public class DocumentServiceTests
{
    [Theory]
    [TestData.ValidFormats]
    public async Task GetDocAsyncSuccess(string contentType)
    {
        var mockStorage = Substitute.For<IDocumentStorage>();
        var doc = new Doc
        {
            Id = new Random().Next(),
            Tags = ["tag1", "tag2"],
            Data = new Dictionary<string, string> { { "key1", "value1" } }
        };
        mockStorage.GetAsync(doc.Id).Returns(doc);
        
        var mockProvider = Substitute.For<ISerializationProvider>();
        mockProvider.ContentType.Returns(contentType);
        
        var expectedFormattedValue = SerializedValue(contentType, doc);
        mockProvider.Serialize(doc).Returns(expectedFormattedValue);

        var mockFactory = Substitute.For<SerializationProviderFactory>(
            new List<ISerializationProvider> { mockProvider });
        mockFactory.GetProvider(contentType).ContentType.Returns(mockProvider.ContentType);
        
        var service = new DocumentService(mockStorage, mockFactory);
        var result = await service.GetDocAsync(doc.Id, contentType);
        
        Assert.Equal(expectedFormattedValue, result);
        
        await mockStorage.Received(1).GetAsync(doc.Id);
        mockProvider.Received(1).Serialize(doc); 
    }

    private static string SerializedValue(string contentType, Doc doc)
    {
        var value = contentType switch
        {
            "application/json" => JsonSerializer.Serialize(doc),
            "application/xml" => HelperMethods.SerializeToXml(doc),
            "application/x-protobuf" => HelperMethods.SerializeToProtobuf(doc),
            "application/x-msgpack" => HelperMethods.SerializeToMessagePack(doc),
            _ => throw new NotSupportedException($"Unsupported content type: {contentType}")
        };

        return value;
    }
}