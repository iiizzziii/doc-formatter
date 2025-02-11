using Xunit.Sdk;
using System.Reflection;

namespace coderama.test;

public abstract class TestData : DataAttribute
{
    public class ValidFormats : TestData
    {
        private const string App = "application/";
        private readonly string[] _formats = [
        "json",
        "xml",
        "x-protobuf",
        "x-msgpack"];

        public override IEnumerable<string[]> GetData(MethodInfo testMethod)
        {
            return _formats.Select(format => (string[])[ string.Concat(App, format) ]);
        }
    }
}