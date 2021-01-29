using System;
using YamlDotNet.Serialization;

namespace DapperDemoApp.Runner
{
    public static class Extensions
    {
        public static void FormatOutPut(this object item)
        {
            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(item);
            Console.WriteLine(yaml);
        }
    }
}
